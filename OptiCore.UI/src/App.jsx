import { useState } from 'react';
import './App.css';
import Header from './components/Header';
import Sidebar from './components/Sidebar';
import Home from './components/Home';
import UserForm from './components/UserForm';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { AuthProvider } from '../src/services/AuthContext'; // Import the AuthProvider component
import PrivateRoute from '../src/helpers/PrivateRoute'; // Corrected import statement
import LoginForm from './components/LoginForm';

function App() {
  const [openSidebarToggle, setOpenSidebarToggle] = useState(false);

  const openSidebar = () => {
    setOpenSidebarToggle(!openSidebarToggle);
  };

  return (
    <Router>
      <AuthProvider>
        <div className='grid-container'>
          <Header OpenSidebar={openSidebar} />
          <Sidebar openSidebarToggle={openSidebarToggle} openSidebar={openSidebar} />
          <Routes>
            <Route exact path="/" element={<Home />} />
            <Route path="/users" element={<PrivateRoute element={<UserForm />} />} />
            <Route path="/loginform" element={<LoginForm />} />
          </Routes>
        </div>
      </AuthProvider>
    </Router>
  );
}

export default App;
