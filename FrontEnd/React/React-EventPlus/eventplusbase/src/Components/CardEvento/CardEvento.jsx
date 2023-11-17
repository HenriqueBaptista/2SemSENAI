import React from 'react';
import './CardEvento.css'

const CardEvento = () => {
    return (
        <div class="card-evento">
            <h3 class="card-evento__titulo">Titulo do Evento</h3>
            <p class="card-evento__text">Breve descrição do evento, pode ser um paragrafo pequenoBreve descrição do evento, pode ser um paragrafo pequeno.Breve descrição do evento, pode ser um paragrafo pequeno.</p>
            <a href="" class="card-evento__conection">Conectar</a>
        </div>
    );
};

export default CardEvento;