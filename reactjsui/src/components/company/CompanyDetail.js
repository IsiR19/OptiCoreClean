// src/CompanyDetails.js
import React, { useEffect, useState } from 'react';
import { getCompanyById } from './CompanyService';

const CompanyDetails = ({ companyId }) => {
    const [company, setCompany] = useState(null);

    useEffect(() => {
        getCompanyById(companyId).then(setCompany);
    }, [companyId]);

    if (!company) return <div>Loading...</div>;

    return (
        <div>
            <h2>{company.name}</h2>
            <p>Registration Number: {company.registrationNumber}</p>
            {/* Display more details as needed */}
        </div>
    );
};

export default CompanyDetails;
