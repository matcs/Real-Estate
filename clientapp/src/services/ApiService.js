import axios from 'axios';

const ApiService = axios.create({
    baseURL: 'https://localhost:44386/api/',
})

export default ApiService; 