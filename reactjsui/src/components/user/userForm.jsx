import React, { useState } from 'react';

class User {
    constructor() {
        this.userId = 0;
        this.fullName = '';
        this.email = '';
        this.type = '';
        this.parentUserId = null;
        this.subordinateUserIds = [];
        this.subordinateCount = 0;
        this.totalCommission = 0;
    }
}

const UserForm = () => {
    const [user, setUser] = useState(new User());

    const handleChange = (e) => {
        const { name, value } = e.target;
        setUser((prevUser) => ({
            ...prevUser,
            [name]: value,
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        // Perform form submission or API request with the user data
        // ...
    };

    return (
        <form onSubmit={handleSubmit} className="container mt-4">
            <div className="row">
                <div className="col-md-6">
                    <div className="mb-3">
                        <label htmlFor="userId" className="form-label">User ID:</label>
                        <input type="number" className="form-control" id="userId" name="userId" value={user.userId} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="fullName" className="form-label">Full Name:</label>
                        <input type="text" className="form-control" id="fullName" name="fullName" value={user.fullName} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="email" className="form-label">Email:</label>
                        <input type="email" className="form-control" id="email" name="email" value={user.email} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="type" className="form-label">Type:</label>
                        <input type="text" className="form-control" id="type" name="type" value={user.type} onChange={handleChange} />
                    </div>
                </div>
                <div className="col-md-6">
                    <div className="mb-3">
                        <label htmlFor="parentUserId" className="form-label">Parent User ID:</label>
                        <input type="number" className="form-control" id="parentUserId" name="parentUserId" value={user.parentUserId} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="subordinateUserIds" className="form-label">Subordinate User IDs:</label>
                        <input type="text" className="form-control" id="subordinateUserIds" name="subordinateUserIds" value={user.subordinateUserIds} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="subordinateCount" className="form-label">Subordinate Count:</label>
                        <input type="number" className="form-control" id="subordinateCount" name="subordinateCount" value={user.subordinateCount} onChange={handleChange} />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="totalCommission" className="form-label">Total Commission:</label>
                        <input type="number" className="form-control" id="totalCommission" name="totalCommission" value={user.totalCommission} onChange={handleChange} />
                    </div>
                </div>
            </div>
            <button type="submit" className="btn btn-primary">Create User</button>
        </form>
    );
};

export default UserForm;
