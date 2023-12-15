import axios from "axios";

const apiPort = "5000";
const localApi = `http://localhost:${apiPort}/api`; // API local
const externalApi = `https://henrique-eventplus-webapp.azurewebsites.net/api`;

const api = axios.create({
    baseURL: externalApi
});


export default api;