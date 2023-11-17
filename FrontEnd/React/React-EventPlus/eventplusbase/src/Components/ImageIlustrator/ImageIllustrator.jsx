import React from 'react';
import "./ImageIllustrator.css";

import imageDefault from "../../assets/images/default-image.jpg"

const ImageIllustrator = ({alterText, imageRender = imageDefault, additionalClass = ''}) => {
    return (
        <figure>
            <img src={imageRender} alt={alterText} className={additionalClass} />
        </figure>
    );
};

export default ImageIllustrator;