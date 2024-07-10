// src/CompanyService.js
import axios from 'axios';

const API_URL = 'http://localhost:5000/api/companies'; // Adjust the port based on your API's address

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

// Add more functions here for POST, PUT, DELETE based on your needs
