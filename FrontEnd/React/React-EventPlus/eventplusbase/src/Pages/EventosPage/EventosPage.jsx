import React, { useState, useEffect } from 'react';
import './EventosPage.css'

import Spinner from '../../Components/Spinner/Spinner';
import { Input, Button, Select } from '../../Components/FormComponents/FormComponents';
import Title from '../../Components/Title/Title';
import Notification from '../../Components/Notification/Notification';
import TableTe from '../EventosPage/TableTe/TableTe';
import MainContent from '../../Components/MainContent/MainContext';
import ImageIllustrator from '../../Components/ImageIlustrator/ImageIllustrator';
import Container from '../../Components/Container/Container';
import api from '../../Services/Service';
import eventImage from '../../assets/images/evento.svg';

const EventosPage = () => {

    const [notfyUser, setNotfyUser] = useState({});
    const [showSpinner, setShowSpinner] = useState(false);
    const [eventos, setEventos] = useState([]);
    const [frmEdit, setFrmEdit] = useState(false);
    const [nomeEvento, setNomeEvento] = useState("");
    const [descricao, setDescricao] = useState("");
    const [idEvento, setIdEvento] = useState();
    const [tiposEvento, setTiposEvento] = useState([]);
    const [dataEvento, setDataEvento] = useState("");
    const [idTiposEvento, setIdTiposEvento] = useState(null);
    const [idInstituicao, setIdInstituicao] = useState("fb4748e1-614f-44bc-8e09-410411b16494");
    const [instituicao, setInstituicao] = useState(null);

    useEffect(() => {
        //chamar a api
        async function getEventos() {
            setShowSpinner(true);

            try {
                const promise = await api.get("/Evento");

                const promise1 = await api.get("/TiposEvento");

                const promise2 = await api.get("/Instituicao");

                setEventos(promise.data);
                setTiposEvento(promise1.data);
                setInstituicao(promise2.data);
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

    async function handleSubmit(e) {
        // parar o submit do formulário
        e.preventDefault();
        // validar pelo menos 3 caracteres
        if (nomeEvento.trim().length < 3) {
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
            console.log(nomeEvento, descricao, idTiposEvento, dataEvento + "T00:00:00.000Z", idInstituicao);
            const retorno = await api.post("/Evento", {
                nomeEvento: nomeEvento,
                descricao: descricao,
                idTipoEvento: idTiposEvento,
                dataEvento: `${dataEvento}T00:00:00.000Z`,
                idInstituicao: idInstituicao
            })
            setNotfyUser({
                titleNote: "Cadastro bem sucedido",
                textNote: "Evento cadastrado com sucesso",
                imgIcon: "success",
                imgAlt: "Icone da ilustração - Sucesso",
                showMessage: true
            });
            setNomeEvento(""); //limpa a variável

            const retornoGet = await api.get('/Evento')

            console.log(retorno.data)

            setEventos(retornoGet.data)
        } catch (error) {
            setNotfyUser({
                titleNote: "Cadastro não sucedido",
                textNote: "Tipo evento não cadastrado, tente novamente",
                imgIcon: "danger",
                imgAlt: "Icone da ilustração - Erro",
                showMessage: true
            });
        }
    }

    async function handleUpdate(e) {
        if (nomeEvento.trim().length < 3) {
            setNotfyUser({
                titleNote: "Caracteres insuficientes",
                textNote: "São necessários pelo menos 3 caracteres",
                imgIcon: "default",
                imgAlt: "Icone da ilustração - Erro",
                showMessage: true
            });

            return null;
        }

        try {
            const retorno = await api.put('/Evento/' + idEvento, {
                nomeEvento: nomeEvento,
                descricao: descricao,
                idTipoEvento: idTiposEvento,
                dataEvento: `${dataEvento}T00:00:00.000Z`,
                idInstituicao: idInstituicao
            })

            const retornoGet = await api.get('/Evento')

            console.log(retorno.data)

            setEventos(retornoGet.data)

            setNotfyUser({
                titleNote: "Evento atualizado",
                textNote: "Atualização de evento bem sucedido",
                imgIcon: "default",
                imgAlt: "Icone da ilustração - Sucesso",
                showMessage: true
            });
        } catch (error) {
            setNotfyUser({
                titleNote: "Falha na atualização",
                textNote: "Verifique sua conexão com a internet",
                imgIcon: "danger",
                imgAlt: "Icone da ilustração - Erro",
                showMessage: true
            });
        }
    }

    async function handleDelete(id) {
        try {
            console.log(id)

            const retorno = await api.delete(`/Evento/${id}`)

            setNotfyUser({
                titleNote: "Deletado com sucesso!",
                textNote: "Tipo evento foi deletado com sucesso!",
                imgIcon: "default",
                imgAlt: "Icone da ilustração - Sucesso",
                showMessage: true
            });

            const retornoGet = await api.get('/Evento')

            console.log(retorno.data)

            setEventos(retornoGet.data)
        } catch (error) {
            console.log("Erro ao excluir");
        }
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
                                        initalValue={""}
                                        placeholder={"Nome"}
                                        required={"required"}
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
                                        manipulationFunction={(e) => {
                                            setDescricao(e.target.value);
                                        }}
                                    />

                                    <Select
                                        id={"tiposEvento"}
                                        name={"tiposEvento"}
                                        alterName={"um Tipo de evento"}
                                        dados={tiposEvento}
                                        required={"required"}
                                        manipulationFunction={(e) => {
                                            setIdTiposEvento(e.target.value)
                                        }}
                                    />

                                    <Input
                                        type={"date"}
                                        id={"dataEvento"}
                                        name={"dataEvento"}
                                        placeholder={"dd/mm/aaaa"}
                                        required={"required"}
                                        manipulationFunction={(e) => {
                                            setDataEvento(e.target.value)
                                        }}
                                    />



                                    <Button
                                        type={"submit"}
                                        id={"cadastrar"}
                                        name={"cadastrar"}
                                        textButton={"Cadastrar"}
                                        manipulationFunction={handleSubmit}
                                    />
                                </>
                            ) : (
                                <>
                                    <Input
                                        type={"text"}
                                        id={"nomeEvento"}
                                        name={"nomeEvento"}
                                        placeholder={"Nome"}
                                        manipulationFunction={(e) => {
                                            setNomeEvento(e.target.value);
                                        }}
                                    />

                                    <Input
                                        type={"text"}
                                        id={"descricao"}
                                        name={"descricao"}
                                        placeholder={"Nova descrição"}
                                        required={"required"}
                                        manipulationFunction={(e) => {
                                            setDescricao(e.target.value)
                                        }}
                                    />

                                    <Select
                                        id={"tiposEvento"}
                                        name={"tiposEvento"}
                                        alterName={"um novo Tipo de evento"}
                                        dados={tiposEvento}
                                        required={"required"}
                                        manipulationFunction={(e) => {
                                            setIdTiposEvento(e.target.value)
                                        }}
                                    />

                                    <Input
                                        type={"date"}
                                        id={"dataEvento"}
                                        name={"dataEvento"}
                                        placeholder={"dd/mm/aaaa"}
                                        manipulationFunction={(e) => {
                                            setDataEvento(e.target.value)
                                        }}
                                    />

                                    <div className="buttons-editbox">
                                        <Button
                                            textButton={"Atualizar"}
                                            id={"atualizar"}
                                            name={"atualizar"}
                                            type={"submit"}
                                            additionalClass="button-component--middle"
                                            manipulationFunction={handleUpdate}
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