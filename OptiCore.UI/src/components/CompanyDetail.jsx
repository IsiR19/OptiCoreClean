import React, { useEffect, useState } from 'react';
import { getCompanyById, createCompany, updateCompany } from '../services/CompanyService';
import { Container, Form, Button, Table } from 'react-bootstrap';
import { useNavigate, useParams } from 'react-router-dom';
import PropTypes from 'prop-types';

const companyTypeMapping = {
    0: 'Channel Partner',
    1: 'Agent',
    // Add more mappings as needed
};

const CompanyDetails = () => {
    const { id } = useParams();
    const [company, setCompany] = useState({
        name: '',
        registrationNumber: '',
        companyType: 0,
        isActive: false,
        linkedCompanies: []
    });
    const navigate = useNavigate();

    useEffect(() => {
        if (id) {
            getCompanyById(id).then(setCompany);
        }
    }, [id]);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setCompany(prevState => ({
            ...prevState,
            [name]: type === 'checkbox' ? checked : value
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (id) {
            await updateCompany(id, company);
        } else {
            await createCompany(company);
        }
        navigate('/companies');
    };

    return (
        <Container>
            <h2>{id ? 'Edit Company' : 'Add Company'}</h2>
            <Form onSubmit={handleSubmit}>
                <Form.Group controlId="formName">
                    <Form.Label>Name</Form.Label>
                    <Form.Control
                        type="text"
                        name="name"
                        value={company.name}
                        onChange={handleChange}
                        required
                    />
                </Form.Group>

                <Form.Group controlId="formRegistrationNumber">
                    <Form.Label>Registration Number</Form.Label>
                    <Form.Control
                        type="text"
                        name="registrationNumber"
                        value={company.registrationNumber}
                        onChange={handleChange}
                        required
                    />
                </Form.Group>

                <Form.Group controlId="formCompanyType">
                    <Form.Label>Company Type</Form.Label>
                    <Form.Control
                        as="select"
                        name="companyType"
                        value={company.companyType}
                        onChange={handleChange}
                        required
                    >
                        <option value={0}>Channel Partner</option>
                        <option value={1}>Agent</option>
                        {/* Add more options as needed */}
                    </Form.Control>
                </Form.Group>

                <Form.Group controlId="formIsActive">
                    <Form.Check
                        type="checkbox"
                        label="Is Active"
                        name="isActive"
                        checked={company.isActive}
                        onChange={handleChange}
                    />
                </Form.Group>

                <Button variant="primary" type="submit">
                    {id ? 'Update Company' : 'Add Company'}
                </Button>
            </Form>

            {id && (
                <>
                    <h3 className="mt-4">Linked Companies</h3>
                    <Table striped bordered hover>
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Registration Number</th>
                                <th>Company Type</th>
                                <th>Active</th>
                            </tr>
                        </thead>
                        <tbody>
                            {company.linkedCompanies.map(linkedCompany => (
                                <tr key={linkedCompany.id}>
                                    <td>{linkedCompany.name}</td>
                                    <td>{linkedCompany.registrationNumber}</td>
                                    <td>{companyTypeMapping[linkedCompany.companyType]}</td>
                                    <td>{linkedCompany.isActive ? 'Yes' : 'No'}</td>
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                </>
            )}
        </Container>
    );
};

CompanyDetails.propTypes = {
    companyId: PropTypes.number
};

export default CompanyDetails;
