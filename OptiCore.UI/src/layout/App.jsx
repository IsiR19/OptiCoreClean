import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import Header from '../features/Navigation/Header';
import Sidebar from '../features/Navigation/Sidebar';
import Home from '../components/Home';
import UserForm from '../components/UserForm';
import LoginForm from '../components/LoginForm';
import PrivateRouteOutlet from '../helpers/PrivateRouteOutlet';
import { AuthProvider } from '../services/AuthContext';
import '../layout/styles.scss';

function App() {
  const [openSidebarToggle, setOpenSidebarToggle] = useState(false);
  const queryClient = new QueryClient();

  const openSidebar = () => {
    setOpenSidebarToggle(!openSidebarToggle);
  };

  return (
    <QueryClientProvider client={queryClient}>
      <Router>
        <AuthProvider>
          <div className="grid-container">
            <Header OpenSidebar={openSidebar} />
            <Sidebar
              openSidebarToggle={openSidebarToggle}
              OpenSidebar={openSidebar}
            />
            <div className="main-container">
              <Routes>
                <Route exact path="/" element={<Home />} />
                <Route exact path="/login" element={<LoginForm />} />
                <Route exact path="/" element={<PrivateRouteOutlet />}>
                  {/* <Route path="" element={<Home />} /> */}
                  <Route
                    path="/users"
                    element={
                      <div className="ml-5">
                        <UserForm />
                      </div>
                    }
                  />
                </Route>
              </Routes>
            </div>
          </div>
        </AuthProvider>
      </Router>
    </QueryClientProvider>
  );
}

export default App;
