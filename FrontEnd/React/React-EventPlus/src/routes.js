import React from 'react';

import { BrowserRouter, Routes, Route } from "react-router-dom";
import HomePage from "./Pages/HomePage/HomePage";
import EventosPage from "./Pages/EventosPage/EventosPage";
import TipoEventoPage from "./Pages/TipoEventoPage/TipoEventoPage";
import LoginPage from "./Pages/LoginPage/LoginPage";

const Rotas = () => {
    return (
        <div>
            <BrowserRouter>
                <Routes>
                    <Route element={<HomePage />} path="/" exact />
                    <Route element={<EventosPage />} path="/eventos" />
                    <Route element={<TipoEventoPage />} path="/tipo-eventos" />
                    <Route element={<LoginPage />} path="/login" />
                </Routes>
            </BrowserRouter>
        </div>
    );
};

export default Rotas;