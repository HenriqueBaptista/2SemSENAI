import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage/homePage';
import LoginPage from './pages/LoginPage/loginPage';
import ProdutoPage from './pages/ProdutoPage/produtoPage';

const Routes = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route element={<HomePage />} path='/' exact />
                <Route element={<LoginPage />} path='/login' />
                <Route element={<ProdutoPage />} path='/produtos' />
            </Routes>
        </BrowserRouter>
    );
};

export default Routes;