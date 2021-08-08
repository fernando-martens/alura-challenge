import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:31455",
  withCredentials: true,
  headers: {
    'Access-Control-Allow-Origin' : "http://localhost:31455",
    'Access-Control-Allow-Credentials': 'false',
    'Access-Control-Allow-Methods':'GET,PUT,POST,DELETE,PATCH,OPTIONS',
    }
});

export default api;