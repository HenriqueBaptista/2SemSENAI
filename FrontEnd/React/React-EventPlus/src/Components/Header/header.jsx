import React from 'react';
import './header.css'
import { Link } from 'react-router-dom';

const Header = () => {
    return (
        <Header>
            <nav>
                <Link href="/">Home</Link>
                <br />

                <Link href="/tipo-eventos">Tipo Eventos</Link>
                <br />

                <Link href="/eventos">Eventos</Link>
                <br />

                <Link href="/login">Login</Link>
            </nav>
        </Header>
    );
};

export default Header;