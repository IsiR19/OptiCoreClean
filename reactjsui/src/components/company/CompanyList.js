// src/CompanyList.js
import React, { useEffect, useState } from 'react';
import { getAllCompanies } from './CompanyService';

const CompanyList = () => {
    const [companies, setCompanies] = useState([]);

    useEffect(() => {
        getAllCompanies().then(setCompanies);
    }, []);

    return (
        <div>
            <h2>Companies</h2>
            <ul>
                {companies.map(company => (
                    <li key={company.id}>{company.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default CompanyList;
