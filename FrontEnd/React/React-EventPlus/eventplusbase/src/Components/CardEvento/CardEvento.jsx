import React from 'react';
import './CardEvento.css'


import dateFormatDbToView from '../../Utils/stringFunction';

import TableDEv from '../../Pages/DetalhesEventoPage/TableDEv/TableDEv';

const CardEvento = ({
    titulo,
    descricao,
    dataEvento,
    showListaComentariosButton,
    showListaComentarios = false,
}) => {
    function setShowListaComentario() {

    }

    return (
        <article className='event-description-card'>
            <h2 className='event-description-card__title'>{titulo}</h2>

            <p className="event-card__description">{descricao}</p>

            <p className="event-card__description">{dateFormatDbToView(dataEvento)}</p>



            {showListaComentarios ?
                <>
                    {TableDEv}
                </>
                :
                <>
                    {null}
                </>}
        </article>
    );
};

export default CardEvento;