import React from "react";
import "./NextEvent.css";
import dateFormatDbToView from "../../Utils/stringFunction";

//new Date(eventDate).toLocaleDateString()

const NextEvent = ({ title, description, eventDate, idEvento }) => {
    function conectar(idEvento) {
        alert(`Conectando ao evento ${idEvento}`);
    }

    return (
        <article className="event-card">
            <h2 className="event-card__title">{title}</h2>

            <p className="event-card__description">{description.substr(0, 16)}...</p>
            <p className="event-card__description">{dateFormatDbToView(eventDate)}</p>

            <a
                href="/"
                className="event-card__connect-link"
                onClick={() => {
                    conectar(idEvento);
                }}
            >
                Conectar
            </a>
        </article>
    );
};

export default NextEvent;