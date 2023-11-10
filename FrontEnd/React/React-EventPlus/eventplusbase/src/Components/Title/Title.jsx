import React from 'react';
import './Title.css'

const Title = ({ titleText, additionalClass = "", color = "" }) => {
    return (
        <h1
            className={`title ${additionalClass}`}
            style={{ color: color }}>


            {titleText}


            <hr
                style={{ borderColor: color }}
                className='title__underscore'
            />
        </h1>
    );
};

export default Title;