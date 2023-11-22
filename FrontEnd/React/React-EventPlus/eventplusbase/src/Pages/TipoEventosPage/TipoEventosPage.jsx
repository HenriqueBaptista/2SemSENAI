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
    const [idEvento, setIdEvento] = useState(null)
    const [showSpinner, setShowSpinner] = useState(false);


    useEffect(() => {
        //chamar a api
        async function getTipoEventos() {
            setShowSpinner(true);

            try {
                const promise = await axios.get(
                    "http://localhost:5000/api/TiposEvento"
                );
                await setTipoEventos(promise.data);
            } catch (error) {
                console.error("Erro : " + error);
                alert("Erro ao carregar os tipos de evento");
            }

            setShowSpinner(false);
        }

        getTipoEventos();
        console.log("A TIPO EVENTOS FOI MONTADA!")
    }, []);


    async function handleSubmit(e) {
        // parar o submit do formulário
        e.preventDefault();
        // validar pelo menos 3 caracteres
        if (titulo.trim().length < 3) {
            setNotfyUser({
                titleNote: "Caracteres insuficientes!",
                textNote: "São necessários pelo menos 3 caracteres!",
                imgIcon: "default",
                imgAlt: "Icone da ilustração - Erro",
                showMessage: true
            });

            return null;
        }
        // chamar a api
        try {
            const retorno = await api.post("/TiposEvento", { titulo: titulo })
            setNotfyUser({
                titleNote: "Cadastro bem sucedido!",
                textNote: "Tipo evento cadastrado com sucesso!",
                imgIcon: "default",
                imgAlt: "Icone da ilustração - Sucesso",
                showMessage: true
            });
            setTitulo(""); //limpa a variável

            const retornoGet = await api.get('/TiposEvento')
            setTipoEventos(retornoGet.data)
        } catch (error) {
            setNotfyUser({
                titleNote: "Cadastro não sucedido",
                textNote: "Tipo evento não cadastrado, tente novamente!",
                imgIcon: "default",
                imgAlt: "Icone da ilustração - Erro",
                showMessage: true
            });
        }
    }

    async function handleUpdate(e) {
        e.preventDefault();

        try {
            const retorno = await api.put('/TiposEvento/' + idEvento, {
                titulo: titulo
            })

            const retornoGet = await api.get('/TiposEvento')
            setTipoEventos(retornoGet.data)
        } catch (error) {
            alert("Problemas na atualização. Verifique a conexão com a internet!")
        }
    }

    async function showUpdateForm(idElemento) {
        setFrmEdit(true);

        try {
            const retorno = await api.get("/TiposEvento/" + idElemento)

            setTitulo(retorno.data.titulo);
            setIdEvento(retorno.data.idTipoEvento);
        }
        catch (error) {
            alert("Não foi possível mostrar a tela de edição, tente novamente!")
        }
    }

    async function handleDelete(idEvento) {
        // chamar a api
        try {
            const retorno = await api.delete(`/TiposEvento/${idEvento}`)

            setNotfyUser({
                titleNote: "Deletado com sucesso!",
                textNote: "Tipo evento foi deletado com sucesso!",
                imgIcon: "default",
                imgAlt: "Icone da ilustração - Sucesso",
                showMessage: true
            });

            const retornoGet = await api.get('/TiposEvento')
            setTipoEventos(retornoGet.data)
        } catch (error) {
            console.log("Erro ao excluir");
        }
    }

    function editActionAbort() {
        setFrmEdit(false);
        setTitulo("");
        setIdEvento(null);
    }

    return (
        <MainContent>
            <Notification {...notfyUser} setNotifyUser={setNotfyUser} />
            {showSpinner ? <Spinner /> : null}
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
                                        manipulationFunction={showUpdateForm}
                                    />
                                </>
                            ) : (
                                <>
                                    <Input
                                        id={"titulo"}
                                        placeholder={"Título"}
                                        name={"titulo"}
                                        type={"text"}
                                        required={"required"}
                                        value={titulo}
                                        manipulationFunction={(e) => {
                                            setTitulo(e.target.value)
                                        }}
                                    />

                                    <div className="buttons-editbox">
                                        <Button
                                            textButton={"Atualizar"}
                                            id={"atualizar"}
                                            name={"atualizar"}
                                            type={"submit"}
                                            additionalClass="button-component--middle"
                                        />

                                        <Button
                                            textButton={"Cancelar"}
                                            id={"cancelar"}
                                            name={"cancelar"}
                                            type={"button"}
                                            manipulationFunction={editActionAbort}
                                            additionalClass="button-component--middle"
                                        />
                                    </div>
                                </>
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