import React from "react";
import "./NextEvent.css";
import dateFormatDbToView from "../../Utils/stringFunction";

//new Date(eventDate).toLocaleDateString()

const NextEvent = ({ title, description, eventDate, idEvento }) => {
    return (
        <article className="event-card">
            <h2 className="event-card__title">{title}</h2>

            <p className="event-card__description">{description}</p>
            <p className="event-card__description">{dateFormatDbToView(eventDate)}</p>

            <a
                href="/"
                className="event-card__connect-link"
            >
            </a>
        </article>
    );
};

export default NextEvent;