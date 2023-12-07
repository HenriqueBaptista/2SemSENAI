import React, { useEffect } from "react";
import trashDelete from "../../assets/images/trash-delete-red.png";

import { Button, Input } from "../FormComponents/FormComponents";
import "./Modal.css";

const Modal = ({
    modalTitle = "Feedback",
    comentaryText,
    userId = null,
    showHideModal = false,
    fnGet = null,
    fnPost = null,
    fnDelete = null,
    fnNewCommentary = null

}) => {

    useEffect(() => {
        fnGet()
    }, []);

    return (
        <div className="modal">
            <article className="modal__box">

                <h3 className="modal__title">
                    {modalTitle}
                    <span className="modal__close" onClick={() => showHideModal(true)}>x</span>
                </h3>

                <div className="comentary">
                    <h4 className="comentary__title">Comentário</h4>
                    <img
                        src={trashDelete}
                        className="comentary__icon-delete"
                        alt="Ícone de uma lixeira"
                        onClick={(e) => {
                            fnDelete()
                        }}
                    />

                    <p className="comentary__text">{comentaryText}</p>

                    <hr className="comentary__separator" />
                </div>

                <Input
                    placeholder="Escreva seu comentário..."
                    additionalClass="comentary__entry"
                />

                <Button
                    textButton="Comentar"
                    additionalClass="comentary__button"
                    manipulationFunction={(e) => {
                        if (e.descricao == null) {
                            fnPost(
                                e.descricao
                            )
                        }
                    }}
                />
            </article>
        </div>
    );
};

export default Modal;
