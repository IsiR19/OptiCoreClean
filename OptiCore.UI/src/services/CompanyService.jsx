import axios from 'axios';

const API_URL = 'https://localhost:7261/api/companies'; // Adjust the port based on your API's address

export const getCompanyById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/${id}`);
        return response.data;
    } catch (error) {
        console.error("There was an error fetching the company data:", error);
        throw error;
    }
};

export const getAllCompanies = async () => {
    try {
        const response = await axios.get(`${API_URL}/All`);
        return response.data;
    } catch (error) {
        console.error("There was an error fetching all companies:", error);
        throw error;
    }
};

export const createCompany = async (company) => {
    try {
        const response = await axios.post(API_URL, company);
        return response.data;
    } catch (error) {
        console.error("There was an error creating the company:", error);
        throw error;
    }
};

export const updateCompany = async (id, company) => {
    try {
        const response = await axios.put(`${API_URL}/${id}`, company);
        return response.data;
    } catch (error) {
        console.error("There was an error updating the company:", error);
        throw error;
    }
};
