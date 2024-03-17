import React, { useState } from 'react'
import { Form, Button,Col } from 'react-bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'

const UserType = {
  ChannelPartner: 'Channel Partner',
  Agent: 'Agent'
};

function UserForm() {
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    type: UserType.ChannelPartner,
    parentUserId: '',
    subordinateUserIds: [],
    subordinateCount: 0,
    totalCommission: 0,
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Submit form data to the server or handle it accordingly
    console.log(formData);
  };

return (
  <Form onSubmit={handleSubmit}>
    <Form.Row>
      <Form.Group as={Col} controlId="formGridFirstName">
        <Form.Label>First Name</Form.Label>
        <Form.Control
          type="text"
          placeholder="Enter first name"
          name="firstName"
          value={formData.firstName}
          onChange={handleChange}
        />
      </Form.Group>

      <Form.Group as={Col} controlId="formGridLastName">
        <Form.Label>Last Name</Form.Label>
        <Form.Control
          type="text"
          placeholder="Enter last name"
          name="lastName"
          value={formData.lastName}
          onChange={handleChange}
        />
      </Form.Group>
    </Form.Row>

    <Form.Group controlId="formGridEmail">
      <Form.Label>Email</Form.Label>
      <Form.Control
        type="email"
        placeholder="Enter email"
        name="email"
        value={formData.email}
        onChange={handleChange}
      />
    </Form.Group>

    <Form.Group controlId="formGridType">
      <Form.Label>User Type</Form.Label>
      <Form.Control
        as="select"
        name="type"
        value={formData.type}
        onChange={handleChange}
      >
        {Object.values(UserType).map((type) => (
          <option key={type} value={type}>
            {type}
          </option>
        ))}
      </Form.Control>
    </Form.Group>

    <Button variant="primary" type="submit">
      Submit
    </Button>
  </Form>
);
}

export default UserForm
