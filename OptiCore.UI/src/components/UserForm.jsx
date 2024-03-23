import  { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

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
    console.log(formData);
  };

  return (
    <form onSubmit={handleSubmit}>
      <div className="form-row">
        <div className="form-group col-md-6">
          <label htmlFor="inputFirstName">First Name</label>
          <input
            type="text"
            className="form-control"
            id="inputFirstName"
            placeholder="Enter first name"
            name="firstName"
            value={formData.firstName}
            onChange={handleChange}
          />
        </div>

        <div className="form-group col-md-6">
          <label htmlFor="inputLastName">Last Name</label>
          <input
            type="text"
            className="form-control"
            id="inputLastName"
            placeholder="Enter last name"
            name="lastName"
            value={formData.lastName}
            onChange={handleChange}
          />
        </div>
      </div>

      <div className="form-group">
        <label htmlFor="inputEmail">Email</label>
        <input
          type="email"
          className="form-control"
          id="inputEmail"
          placeholder="Enter email"
          name="email"
          value={formData.email}
          onChange={handleChange}
        />
      </div>

      <div className="form-group">
        <label htmlFor="inputType">User Type</label>
        <select
          id="inputType"
          className="form-control"
          name="type"
          value={formData.type}
          onChange={handleChange}
        >
          {Object.values(UserType).map((type) => (
            <option key={type} value={type}>
              {type}
            </option>
          ))}
        </select>
      </div>

      <button type="submit" className="btn btn-primary">
        Submit
      </button>
    </form>
  );
}

export default UserForm;
