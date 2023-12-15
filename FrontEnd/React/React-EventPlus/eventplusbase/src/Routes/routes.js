import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom"; //v6

// imports dos componentes de página
import HomePage from "../Pages/HomePage/HomePage";
import TipoEventos from "../Pages/TipoEventosPage/TipoEventosPage";
import EventosPage from "../Pages/EventosPage/EventosPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import Header from "../Components/Header/Header";
import Footer from "../Components/Footer/Footer";
import { PrivateRoute } from "./PrivateRoute";
import EventosAlunoPage from "../Pages/EventosAlunoPage/EventosAlunoPage";
import DetalhesEventosPage from "../Pages/DetalhesEventoPage/DetalhesEventosPage";

// Componente Rota
const Rotas = () => {
  return (
    <BrowserRouter>
      <Header />

      <Routes>
        <Route element={<HomePage />} path="/" exact />

        <Route
          path="/tipo-eventos"
          element={
            <PrivateRoute redirectTo="/">
              <TipoEventos />
            </PrivateRoute>
          }
        />

        <Route
          path="/eventos"
          element={
            <PrivateRoute redirectTo="/">
              <EventosPage />
            </PrivateRoute>
          }
        />

        <Route
          path="/evento-aluno"
          element={
            <PrivateRoute redirectTo="/">
              <EventosAlunoPage />
            </PrivateRoute>
          }
        />

        <Route
          path="/detalhes-evento"
          element={
            <PrivateRoute redirectTo="/">
              <DetalhesEventosPage />
            </PrivateRoute>
          }
        />

        <Route element={<LoginPage />} path="/login" />
      </Routes>

      <Footer />
    </BrowserRouter>
  );
};

export default Rotas;