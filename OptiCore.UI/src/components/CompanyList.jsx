import React, { useEffect, useState } from 'react';
import { getAllCompanies } from '../services/CompanyService';
import { Container, Row, Col, Table, Button, Form, Pagination } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

const companyTypeMapping = {
    0: 'Channel Partner',
    1: 'Agent',
    // Add more mappings as needed
};

const CompanyList = () => {
    const [companies, setCompanies] = useState([]);
    const [filteredCompanies, setFilteredCompanies] = useState([]);
    const [filters, setFilters] = useState({
        name: '',
        registrationNumber: '',
        companyType: '',
        isActive: ''
    });
    const [currentPage, setCurrentPage] = useState(1);
    const [companiesPerPage] = useState(10); // Adjust the number of companies per page as needed
    const navigate = useNavigate();

    useEffect(() => {
        getAllCompanies().then(data => {
            setCompanies(data);
            setFilteredCompanies(data);
        });
    }, []);

    useEffect(() => {
        applyFilters();
    }, [filters, companies]);

    const applyFilters = () => {
        let filtered = companies;

        if (filters.name) {
            filtered = filtered.filter(company => company.name.toLowerCase().includes(filters.name.toLowerCase()));
        }

        if (filters.registrationNumber) {
            filtered = filtered.filter(company => company.registrationNumber.includes(filters.registrationNumber));
        }

        if (filters.companyType) {
            filtered = filtered.filter(company => company.companyType.toString() === filters.companyType);
        }

        if (filters.isActive) {
            filtered = filtered.filter(company => company.isActive.toString() === filters.isActive);
        }

        setFilteredCompanies(filtered);
        setCurrentPage(1); // Reset to the first page whenever filters change
    };

    const handleFilterChange = (e) => {
        const { name, value } = e.target;
        setFilters({
            ...filters,
            [name]: value
        });
    };

    const handleRowClick = (id) => {
        navigate(`/companies/${id}`);
    };

    // Pagination Logic
    const indexOfLastCompany = currentPage * companiesPerPage;
    const indexOfFirstCompany = indexOfLastCompany - companiesPerPage;
    const currentCompanies = filteredCompanies.slice(indexOfFirstCompany, indexOfLastCompany);

    const paginate = (pageNumber) => setCurrentPage(pageNumber);

    return (
        <Container>
            <Row className="my-4">
                <Col><h2>Companies</h2></Col>
                <Col className="text-end">
                    <Button variant="primary" onClick={() => navigate('/companies/add')}>
                        Add Company
                    </Button>
                </Col>
            </Row>
            <Form>
                <Row className="mb-3">
                    <Col>
                        <Form.Group controlId="filterName">
                            <Form.Label>Name</Form.Label>
                            <Form.Control
                                type="text"
                                name="name"
                                value={filters.name}
                                onChange={handleFilterChange}
                                placeholder="Filter by name"
                            />
                        </Form.Group>
                    </Col>
                    <Col>
                        <Form.Group controlId="filterRegistrationNumber">
                            <Form.Label>Registration Number</Form.Label>
                            <Form.Control
                                type="text"
                                name="registrationNumber"
                                value={filters.registrationNumber}
                                onChange={handleFilterChange}
                                placeholder="Filter by registration number"
                            />
                        </Form.Group>
                    </Col>
                    <Col>
                        <Form.Group controlId="filterCompanyType">
                            <Form.Label>Company Type</Form.Label>
                            <Form.Control
                                as="select"
                                name="companyType"
                                value={filters.companyType}
                                onChange={handleFilterChange}
                            >
                                <option value="">All</option>
                                {Object.entries(companyTypeMapping).map(([key, value]) => (
                                    <option key={key} value={key}>{value}</option>
                                ))}
                            </Form.Control>
                        </Form.Group>
                    </Col>
                    <Col>
                        <Form.Group controlId="filterIsActive">
                            <Form.Label>Active</Form.Label>
                            <Form.Control
                                as="select"
                                name="isActive"
                                value={filters.isActive}
                                onChange={handleFilterChange}
                            >
                                <option value="">All</option>
                                <option value="true">Yes</option>
                                <option value="false">No</option>
                            </Form.Control>
                        </Form.Group>
                    </Col>
                </Row>
            </Form>
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
                    {currentCompanies.map(company => (
                        <tr key={company.id} onClick={() => handleRowClick(company.id)} style={{ cursor: 'pointer' }}>
                            <td>{company.name}</td>
                            <td>{company.registrationNumber}</td>
                            <td>{companyTypeMapping[company.companyType]}</td>
                            <td>{company.isActive ? 'Yes' : 'No'}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
            <Pagination>
                {Array.from({ length: Math.ceil(filteredCompanies.length / companiesPerPage) }, (_, index) => (
                    <Pagination.Item
                        key={index + 1}
                        active={index + 1 === currentPage}
                        onClick={() => paginate(index + 1)}
                    >
                        {index + 1}
                    </Pagination.Item>
                ))}
            </Pagination>
        </Container>
    );
};

export default CompanyList;
