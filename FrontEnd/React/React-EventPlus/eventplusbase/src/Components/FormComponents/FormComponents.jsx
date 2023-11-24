import React from 'react';
import './FormComponents.css'

export const Input = ({
    type,
    id,
    name,
    required,
    additionalClass = '',
    placeholder,
    manipulationFunction
}) => {
    return (
        <input
            type={type}
            id={id}
            name={name}
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
    additionalClass = "",
    manipulationFunction
}) => {
    return (
        <button
            type={type}
            name={name}
            id={id}
            className={`button-component ${additionalClass}`
            }
            onClick={manipulationFunction}
        >
            {textButton}
        </button>
    )
}

export const Select = ({
    dados = [],
    id,
    name,
    required,
    additionalClass,
    manipulationFunction,
    defaultValue,
    alterName,
    valor,
}) => {
    return (
        <select
            id={id}
            name={name}
            required={required}
            className={'input-component ' + { additionalClass }}
            onClick={manipulationFunction}
            value={defaultValue}
        >
            <option value="">Selecione {alterName}</option>

            {dados.map((opt) => {
                return (
                    <option key={opt.idTipoEvento} value={opt.idTipoEvento}>{opt.titulo}</option>
                )
            })}
        </select>
    )
}