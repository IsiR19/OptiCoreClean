import { useEffect, useState } from 'react';
import './App.css';
import React from 'react';
import UserForm from './components/user/userForm';
import Navbar from './components/Navbar/Navbar'
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';


const App = () => {
    return (
        <div className="container-fluid">
            <div className="row">
                <div className="col-lg-3 col-md-4 col-sm-12 bg-light">
                    <Navbar />
                </div>
                <div className="col-lg-9 col-md-8 col-sm-12">
                    <div className="container mt-4">
                        <UserForm />
                    </div>
                </div>
            </div>
        </div>
    );
};

export default App;