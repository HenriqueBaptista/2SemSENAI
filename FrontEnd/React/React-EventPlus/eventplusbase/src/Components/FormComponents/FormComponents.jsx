import React from 'react';
import './FormComponents.css'

export const Input = ({
    type,
    id,
    required,
    additionalClass = '',
    placeholder,
    manipulationFunction
}) => {
    return (
        <input
            type={type}
            id={id}
            required={required}
            className={`input-component ${additionalClass}`}
            placeholder={placeholder}
            onChange={manipulationFunction}
            autoComplete='off'
        />
    );
};;

export const Button = ({
    textButton,
    id,
    name,
    type,
    additionalClass = ""
}) => {
    return (
        <button
            type={type}
            name={name}
            id={id}
            className={`button-component ${additionalClass}`
            }>
            {textButton}
        </button>
    )
}