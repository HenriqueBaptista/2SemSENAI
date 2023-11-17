import React, { useEffect, useState } from "react";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";

import MainContent from "../../Components/MainContent/MainContext"
import ImageIllustrator from "../../Components/ImageIlustrator/ImageIllustrator";
import eventTypeImage from "../../assets/images/tipo-evento.svg";
import Container from "../../Components/Container/Container";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Service";
import TableTb from "./TableTb/TableTb";
import axios from "axios";
import Spinner from "../../Components/Spinner/Spinner"
import Notification from "../../Components/Notification/Notification"

const TipoEventosPage = () => {
    const [notfyUser, setNotfyUser] = useState({})
    const [tipoEventos, setTipoEventos] = useState([]);
    const [frmEdit, setFrmEdit] = useState(false);
    const [titulo, setTitulo] = useState("");


    useEffect(() => {
        //chamar a api
        async function getTipoEventos() {
            try {
                const promise = await axios.get(
                    "http://localhost:5000/api/TiposEvento"
                );
                await setTipoEventos(promise.data);
            } catch (error) {
                console.error("Erro : " + error);
                alert("Erro ao carregar os tipos de evento");
            }
        }

        getTipoEventos();
        console.log("A TIPO EVENTOS FOI MONTADA!")
    }, []);


    async function handleSubmit(e) {
        // parar o submit do formulário
        e.preventDefault();
        // validar pelo menos 3 caracteres
        if (titulo.trim().length < 3) {
            alert("O Título deve ter no mínimo 3 caracteres")
            return;
        }
        // chamar a api
        try {
            const retorno = await api.post("/TiposEvento", { titulo: titulo })
            console.log("CADASTRADO COM SUCESSO");
            console.log(retorno.data);
            setTitulo(""); //limpa a variável

            const retornoGet = await api.get('/TiposEvento')
            setTipoEventos(retornoGet.data)
        } catch (error) {
            console.log("Deu ruim na api:");
            console.log(error);
        }
    }

    function handleUpdate() {
        alert("Bora Atualizar");
    }

    function showUpdateForm() {
        alert("Mostrando a tela de update");
    }

    async function handleDelete(idEvento) {
        // chamar a api
        try {
            const retorno = await api.delete(`/TiposEvento/${idEvento}`)

            alert("Registro apagado com sucesso")

            const retornoGet = await api.get('/TiposEvento')
            setTipoEventos(retornoGet.data)
        } catch (error) {
            console.log("Erro ao excluir");
        }
    }

    function editActionAbort() {
        alert("Cancelar a tela de edição de dados")
    }

    return (
        <MainContent>
            <Notification />
            {/* Cadastro de tipos de evento */}
            <section className="cadastro-evento-section">
                <Container>
                    <div className="cadastro-evento__box">
                        <Title titleText={"Página Tipos de Eventos"} />
                        <ImageIllustrator
                            alterText={"??????"}
                            imageRender={eventTypeImage}
                        />

                        <form
                            className="ftipo-evento"
                            onSubmit={frmEdit ? handleUpdate : handleSubmit}
                        >
                            {!frmEdit ? (
                                <>
                                    {/* Cadastrar */}
                                    <Input
                                        type={"text"}
                                        id={"titulo"}
                                        name={"titulo"}
                                        placeholder={"Título"}
                                        required={"required"}
                                        value={titulo}
                                        manipulationFunction={
                                            (e) => {
                                                setTitulo(e.target.value)
                                            }
                                        }
                                    />
                                    <span>{titulo}</span>
                                    <Button
                                        type={"submit"}
                                        id={"cadastrar"}
                                        name={"cadastrar"}
                                        textButton={"Cadastrar"}
                                    />
                                </>
                            ) : (
                                <p>Tela de Edição</p>
                            )}

                            {/*  */}
                        </form>
                    </div>
                </Container>
            </section>

            {/* Listagem de tipos de evento */}
            <section className="lista-eventos-section">
                <Container>
                    <Title titleText={"Lista Tipo de Eventos"} color="white" />

                    <TableTb
                        dados={tipoEventos}
                        fnUpdate={showUpdateForm}
                        fnDelete={handleDelete}
                    />
                </Container>
            </section>
        </MainContent>
    );
};

export default TipoEventosPage;