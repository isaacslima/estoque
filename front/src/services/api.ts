import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:51517'
});

export default api;