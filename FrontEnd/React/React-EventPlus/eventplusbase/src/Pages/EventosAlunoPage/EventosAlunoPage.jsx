import React, { useContext, useEffect, useState } from "react";
import MainContent from "../../Components/MainContent/MainContext";
import Title from "../../Components/Title/Title";
import Table from "./TableEvA/TableEvA";
import Container from "../../Components/Container/Container";
import { Select } from "../../Components/FormComponents/FormComponents";
import Spinner from "../../Components/Spinner/Spinner";
import Modal from "../../Components/Modal/Modal";
import api from "../../Services/Service";

import "./EventosAlunoPage.css";
import { UserContext } from "../../context/AuthContext";

const EventosAlunoPage = () => {
    // state do menu mobile
    const [eventos, setEventos] = useState([]);
    // select mocado
    const [quaisEventos, setQuaisEventos] = useState([
        { value: 1, text: "Todos os eventos" },
        { value: 2, text: "Meus eventos" },
    ]);

    const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
    const [showSpinner, setShowSpinner] = useState(false);
    const [showModal, setShowModal] = useState(false);
    const [comentario, setComentario] = useState("");

    // recupera os dados globais do usuário
    const { userData } = useContext(UserContext);

    async function loadEventsType() {
        setShowSpinner(true)

        try {
            if (tipoEvento === "1") { // Todos os tipos de evento
                const promise = await api.get("/Evento");
                const promise1 = await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`);

                const dadosMarcados = verificarPresenca(promise.data, promise1.data);
                console.clear();
                console.log("DADOS MARCADOS");
                console.log(dadosMarcados);

                setEventos(dadosMarcados);

            } else {
                let arrEventos = [];
                const promiseEventos = await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`);

                promiseEventos.data.forEach((element) => {
                    arrEventos.push({
                        ...element.evento,
                        situacao: element.situacao,
                        idPresencaEvento: element.idPresencaEvento
                    });
                });

                setEventos(arrEventos);
            }

        } catch (error) {
            console.error("Erro : ", error)
        }

        setShowSpinner(false)
    };

    useEffect(() => {

        loadEventsType();
    }, [tipoEvento, userData.userId]);

    const verificarPresenca = (arrAllEvents, eventsUser) => {
        for (let x = 0; x < arrAllEvents.length; x++) {
            for (let i = 0; i < eventsUser.length; i++) {
                if (arrAllEvents[x].idEvento === eventsUser[i].evento.idEvento) {
                    arrAllEvents[x].situacao = true;

                    arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento;

                    break
                }
            }
        }
        return arrAllEvents;
    }

    // toggle meus eventos ou todos os eventos
    function myEvents(tpEvent) {
        setTipoEvento(tpEvent);
    }

    // Lê os comentários
    const loadMyComentary = async () => {
        const promiseToRead = await api.get("")
    }

    // Cadastra o comentário
    const submitMyComentary = async () => {

    }

    // Remove o comentário - Delete
    const commentaryRemove = async () => {
        alert("Remove o comentário");
    };

    const updateMyComentary = async () => {

    }

    const showHideModal = () => {
        setShowModal(showModal ? false : true);
    };

    async function handleConnect(idEvent, whatTheFunction, idPresenca = null) {
        if (whatTheFunction === "connect") { // Se a função for connect:
            try {
                const promiseToConnect = await api.post("/PresencasEvento", {
                    situacao: true,
                    idUsuario: userData.userId,
                    idEvento: idEvent
                });

                if (promiseToConnect.status === 201) {
                    console.log("Presença confirmada, parabéns!")
                }

                loadEventsType();

                return;

            } catch (error) {
                console.log("Erro ao conectar");
                console.log(error);
            }
        } else { // Se a função não for connect:
            try {
                const promiseToDisconnect = await api.delete("/PresencasEvento/" + idPresenca);

                console.log(promiseToDisconnect.status);

                loadEventsType();

                return;
            } catch (error) {
                console.log("Erro ao desconectar");
                console.log(error);
            }
        }
    }
    return (
        <>
            <MainContent>
                <Container>
                    <Title titleText={"Eventos"} additionalClass="custom-title" />

                    <Select
                        id="id-tipo-evento"
                        name="tipo-evento"
                        required={true}
                        dados={quaisEventos} // aqui o array dos tipos
                        manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
                        defaultValue={tipoEvento}
                        additionalClass="select-tp-evento"
                    />
                    <Table
                        dados={eventos}
                        fnConnect={handleConnect}
                        fnShowModal={() => {
                            showHideModal();
                        }}
                    />
                </Container>
            </MainContent>

            {/* SPINNER -Feito com position */}
            {showSpinner ? <Spinner /> : null}

            {showModal ? (
                <Modal
                    userId={userData.userId}
                    showHideModal={showHideModal}
                    comentaryText={comentario}
                    fnGet={loadMyComentary}
                    fnPost={submitMyComentary}
                    fnNewCommentary={updateMyComentary}
                    fnDelete={commentaryRemove}
                />
            ) : null}
        </>
    );
};

export default EventosAlunoPage;
