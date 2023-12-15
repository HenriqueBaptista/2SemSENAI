import { jwtDecode } from "jwt-decode";
import { createContext } from "react";

export const UserContext = createContext(null);

export const userDecodeToken = (theToken) => {
    const decoded = jwtDecode(theToken); // Aqui retorna o payload

    return {
        role: decoded.role,
        name: decoded.name,
        userId: decoded.jti,
        token: theToken
    };
};