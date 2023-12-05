import React, { useEffect, useState } from 'react';
import './HomePage.css';

import MainContent from '../../Components/MainContent/MainContext';
import Banner from '../../Components/Banner/Banner';
import Container from '../../Components/Container/Container'
import Title from '../../Components/Title/Title';
import NextEvent from '../../Components/NextEvent/NextEvent';
import VisionSection from '../../Components/VisionSection/VisionSection';
import ContactSection from '../../Components/ContactSection/ContactSection'

import axios from 'axios';

const HomePage = () => {
    useEffect(() => {
        //chamar a api
        async function getProximosEventos() {
            try {
                const promise = await axios.get(
                    "http://localhost:5000/api/Evento/ListarProximos"
                );
                console.log(promise.data);
            } catch (error) {
                console.error("Erro : " + error);
                alert("Erro ao carregar os eventos");
            }
        }

        getProximosEventos();
    }, []);

    // fake mock - api mocada
    const [nextEvents, setNextEvents] = useState([]);

    return (
        <MainContent>
            <Banner />

            <section className="proximos-eventos">
                <Container>
                    <Title titleText={"Próximos Eventos"} />

                    <div className="events-box">
                        {nextEvents.map((event) => (
                            <NextEvent
                                key={event.idEvento}
                                title={event.nomeEvento}
                                description={event.descricao}
                                eventDate={event.dataEvento}
                                idEvento={event.idEvento}
                            />
                        ))}
                    </div>
                </Container>

                <VisionSection />

                <ContactSection />
            </section>
        </MainContent>
    );
};

export default HomePage;