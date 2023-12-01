import React, { useContext, useEffect, useState } from "react";


import ImageIllustrator from "../../Components/ImageIlustrator/ImageIllustrator";
import logo from "../../assets/images/logo-pink.svg";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import loginImage from "../../assets/images/login.svg";

import api from "../../Services/Service";

import "./LoginPage.css";
import { UserContext, userDecodeToken } from "../../context/AuthContext";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
    // Dados globais do formulário
    const { userData, setUserData } = useContext(UserContext)
    const navigate = useNavigate();

    useEffect(() => {
        if (userData.name) navigate("/");
    }, [userData]);

    const [user, setUser] = useState({
        email: "",
        senha: "",
    })

    async function handleSubmit(e) {
        e.preventDefault();

        if (user.email.length >= 3 && user.senha.length > 3) {
            // Chamar a Api
            try {
                const promise = await api.post("/Login", {
                    email: user.email,
                    senha: user.senha
                })

                const userFullToken = userDecodeToken(promise.data.token);

                setUserData(userFullToken); //Guarda os dados modificados (payload)
                localStorage.setItem("token", JSON.stringify(userFullToken));

                navigate("/") // Manda o usuário para a home

            } catch (error) {
                alert("Usuário e senha inválidos ou conexão com a internet interrompida")
            }
        } else {
            alert("Preencha os campos corretamente!")
        }
    }


    return (
        <div className="layout-grid-login">
            <div className="login">
                <div className="login__illustration">
                    <div className="login__illustration-rotate"></div>
                    <ImageIllustrator
                        imageRender={loginImage}
                        altText="Imagem de um homem em frente de uma porta de entrada"
                        additionalClass="login-illustrator"
                    />
                </div>

                <div className="frm-login">
                    <img src={logo} className="frm-login__logo" alt="" />

                    <form className="frm-login__formbox" onSubmit={handleSubmit}>
                        <Input
                            additionalClass="frm-login__entry"
                            type="email"
                            id="login"
                            name="login"
                            required={true}
                            value={user.email}
                            manipulationFunction={(e) => {
                                setUser({
                                    ...user,
                                    email: e.target.value.trim()
                                })
                            }}
                            placeholder="Username"
                        />
                        <Input
                            additionalClass="frm-login__entry"
                            type="password"
                            id="senha"
                            name="senha"
                            required={true}
                            value={user.senha}
                            manipulationFunction={(e) => {
                                setUser({
                                    ...user,
                                    senha: e.target.value.trim()
                                })
                            }}
                            placeholder="****"
                        />

                        <a className="frm-login__link">
                            Esqueceu a senha?
                        </a>

                        <Button
                            textButton="Login"
                            id="btn-login"
                            name="btn-login"
                            type="submit"
                            additionalClass="frm-login__button"
                        />
                    </form>
                </div>
            </div>
        </div>
    );
};

export default LoginPage;
