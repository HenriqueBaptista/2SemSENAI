import React, { useState, useEffect } from 'react';
import './EventosPage.css'

import Spinner from '../../Components/Spinner/Spinner';
import { Input, Button } from '../../Components/FormComponents/FormComponents';
import Title from '../../Components/Title/Title';
import Notification from '../../Components/Notification/Notification';
import TableTe from '../EventosPage/TableTe/TableTe';
import MainContent from '../../Components/MainContent/MainContext';
import ImageIllustrator from '../../Components/ImageIlustrator/ImageIllustrator';
import Container from '../../Components/Container/Container';
import api from '../../Services/Service';
import axios from 'axios';
import eventImage from '../../assets/images/evento.svg';

const EventosPage = () => {

    const [notfyUser, setNotfyUser] = useState({});
    const [showSpinner, setShowSpinner] = useState(false);
    const [eventos, setEventos] = useState([]);
    const [frmEdit, setFrmEdit] = useState(false);
    const [nomeEvento, setNomeEvento] = useState("");
    const [descricao, setDescricao] = useState("");
    const [idEvento, setIdEvento] = useState(null);

    useEffect(() => {
        //chamar a api
        async function getEventos() {
            setShowSpinner(true);

            try {
                const promise = await axios.get(
                    "http://localhost:5000/api/Evento"
                );
                await setEventos(promise.data);
            } catch (error) {
                console.error("Erro : " + error);
                alert("Erro ao carregar os eventos");
            }

            setShowSpinner(false);
        }

        getEventos();
        console.log("A EVENTOS FOI MONTADA!")
    }, []);

    async function showUpdateForm(idElemento) {
        setFrmEdit(true);

        try {
            const retorno = await api.get("/Evento/" + idElemento)

            setNomeEvento(retorno.data.nomeEvento);
            setIdEvento(retorno.data.idEvento);
        }
        catch (error) {
            alert("Não foi possível mostrar a tela de edição, tente novamente!")
        }
    }

    function editActionAbort() {
        setFrmEdit(false);
        setIdEvento(null);
    }

    function handleSubmit() {

    }

    function handleUpdate() {

    }

    function handleDelete() {

    }


    return (
        <MainContent>
            <Notification {...notfyUser} setNotifyUser={setNotfyUser} />

            {showSpinner ? <Spinner /> : null}

            <section className='cadastro-evento-section'>
                <Container>
                    <div className="cadastro-evento__box">
                        <Title titleText={"Página de eventos"} />

                        <ImageIllustrator
                            alterText={"Imagem da tela de cadastro de eventos"}
                            imageRender={eventImage}
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
                                        id={"nomeEvento"}
                                        name={"nomeEvento"}
                                        placeholder={"Nome"}
                                        required={"required"}
                                        value={nomeEvento}
                                        manipulationFunction={(e) => {
                                            setNomeEvento(e.target.value);
                                        }}
                                    />

                                    <Input
                                        type={"text"}
                                        id={"descricao"}
                                        name={"descricao"}
                                        placeholder={"Descrição"}
                                        required={"required"}
                                        value={descricao}
                                    />

                                    <Input
                                        type={"text"}
                                        id={"tipoEvento"}
                                        name={"tipoEvento"}
                                        placeholder={"Tipo Evento"}
                                        required={"required"}
                                    />

                                    <Input
                                        type={"date"}
                                        id={"dataEvento"}
                                        name={"dataEvento"}
                                        placeholder={"dd/mm/aaaa"}
                                        required={"required"}
                                    />

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
                                        type={"text"}
                                        id={"nomeEvento"}
                                        name={"nomeEvento"}
                                        placeholder={"Novo nome"}
                                        required={"required"}
                                        value={nomeEvento}
                                        manipulationFunction={(e) => {
                                            setNomeEvento(`Novo evento: ${e.target.value}`);
                                        }}
                                    />

                                    <Input
                                        type={"text"}
                                        id={"descricao"}
                                        name={"descricao"}
                                        placeholder={"Nova descrição"}
                                        required={"required"}
                                    />

                                    <Input
                                        type={"text"}
                                        id={"tipoEvento"}
                                        name={"tipoEvento"}
                                        placeholder={"Tipo Evento"}
                                        required={"required"}
                                    />

                                    <Input
                                        type={"date"}
                                        id={"dataEvento"}
                                        name={"dataEvento"}
                                        placeholder={"Nova data: dd/mm/aaaa"}
                                        required={"required"}
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
                        </form>
                    </div>
                </Container>

            </section>


            {/* Listagem de tipos de evento */}
            <section className="lista-eventos-section">
                <Container>
                    <Title titleText={"Lista de Eventos"} color="white" />

                    <TableTe
                        dados={eventos}
                        fnUpdate={showUpdateForm}
                        fnDelete={handleDelete}
                    />
                </Container>
            </section>
        </MainContent>
    );
};

export default EventosPage;