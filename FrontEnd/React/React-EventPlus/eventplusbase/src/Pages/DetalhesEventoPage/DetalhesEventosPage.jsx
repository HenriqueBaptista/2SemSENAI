import React, { useContext, useEffect, useState } from 'react';
import './DetalhesEventosPage.css';

import MainContent from '../../Components/MainContent/MainContext';
import Container from '../../Components/Container/Container';
import Title from '../../Components/Title/Title';
import Spinner from '../../Components/Spinner/Spinner';
import CardEvento from '../../Components/CardEvento/CardEvento';

import api from '../../Services/Service';
import { UserContext } from '../../context/AuthContext';


const DetalhesEventosPage = () => {
    // Usar os dados do usuário
    const { userData } = useContext(UserContext);

    // States
    const [verTodosEventos, setVerTodosEventos] = useState(false);
    const [showSpinner, setShowSpinner] = useState(false);

    // Ler eventos - Adm ou Estudante
    async function readCommentary() {
        setShowSpinner(true);

        try {
            if (userData.role === "Administrador") { // Se usuário for administrador
                // Trás todos os comentários para os adms, mesmo que contenham palavras ofensivas
                const promiseAdmin = await api.get("/ComentariosEvento");

                console.log(promiseAdmin.data);

                setVerTodosEventos(true);
            }
            else { // Senão
                // Trás todos os comentários que não contenham palavras ofensivas
                const promiseStudent = await api.get("/ComentariosEvento/ListarIa");

                console.log(promiseStudent.data);

                setVerTodosEventos(false); // Poderá ver apenas aqueles que a IA deixar
            }
        } catch (error) {
            console.error("Erro: ", error);
        }

        setShowSpinner(false);
    };

    // Effect para renderização
    useEffect(() => {
        readCommentary()
    }, [verTodosEventos, userData.role]);

    // Funções
    const lerEventos = async () => {

    }

    const lerComentarios = async () => {

    }

    const [eventos, setEventos] = useState([]);

    return (
        <>
            <MainContent>
                <Container>
                    <Title titleText={"Detalhes de Eventos"} additionalClass='custom-title' />

                    {showSpinner ? <Spinner /> : null}

                    <div className="events-box">

                        {
                            eventos.map((e) => {
                                return (
                                    <CardEvento
                                    titulo={e.nomeEvento}
                                    />
                                );
                            })
                        }

                    </div>

                </Container>
            </MainContent>
        </>
    );
};

export default DetalhesEventosPage;