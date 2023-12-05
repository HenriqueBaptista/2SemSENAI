import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

// import dos componentes de página
import HomePage from "../Pages/HomePage/HomePage";
import TipoEventosPage from "../Pages/TipoEventosPage/TipoEventosPage";
import EventosPage from "../Pages/EventosPage/EventosPage";
import LoginPage from "../Pages/LoginPage/LoginPage";

import Header from "../Components/Header/Header";
import Footer from "../Components/Footer/Footer";
import PrivateRoute from "./PrivateRoute";
import EventosAlunoPage from "../Pages/EventosAlunoPage/EventosAlunoPage";


const Rotas = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route element={<HomePage />} path="/" exact />

        <Route element={
          <PrivateRoute redirectTo="/">
            <TipoEventosPage />
          </PrivateRoute>} path="/tipo-eventos" />

        <Route path="/eventos" element={
          <PrivateRoute redirectTo="/">
            <EventosPage />
          </PrivateRoute>
        } />

        <Route element={<EventosAlunoPage />} path="/eventos-alunos" />

        <Route element={<LoginPage />} path="/login" />
      </Routes>
      <Footer />
    </BrowserRouter>
  );
};

export default Rotas;