import React from 'react';
import { Route, Navigate } from 'react-router-dom';
import { useAuth } from '../services/AuthContext';

const PrivateRoute = ({ element, ...rest }) => {
  const { user } = useAuth();

  // No need to rename element to Component, just use it directly
  return (
    <Route
      {...rest}
      element={user ? element : <Navigate to="/loginForm" replace />}
    />
  );
};

export default PrivateRoute;
