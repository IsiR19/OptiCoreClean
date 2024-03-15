// api/apiClient.js
import axios from 'axios';
import apiConfig from './apiConfig';

const apiClient = axios.create({
    baseURL: apiConfig.baseUrl,
});

export const get = (url) => apiClient.get(url);
export const post = (url, data) => apiClient.post(url, data);
export const put = (url, data) => apiClient.put(url, data);
export const del = (url) => apiClient.delete(url);
