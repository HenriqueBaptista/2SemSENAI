import React, { useState } from "react";
import './contador.css';

const Contador = () => {
    const [contador, setContador] = useState(0)

    function handleIncrementar() {
        setContador(contador + 1);
    };

    function handleDecrementar() {
        if (contador > 0) {
            setContador(contador - 1);
        }
    }

    return (
        <>
            <p>{contador}</p>
            <button onClick={handleIncrementar}>Incrementar</button>
            <button onClick={handleDecrementar}>Decrementar</button>
        </>
    );
};

export default Contador;