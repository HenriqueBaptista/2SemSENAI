import React from "react";
import './card-evento.css';

const CardEvento = (props) => {
    return (
        <div class="card-evento">
            <h3 class="card-evento__titulo">Evento: {props.tituloCard}</h3>
            <p class="card-evento__text">Breve descrição do evento, pode ser um paragrafo pequenoBreve descrição do evento, pode ser um paragrafo pequeno.Breve descrição do evento, pode ser um paragrafo pequeno.</p>
            <a class="card-evento__conection">Conectar</a>
        </div>
    );
};

export default CardEvento;