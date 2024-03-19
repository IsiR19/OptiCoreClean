import React from 'react';
import { Navigate } from 'react-router-dom';
import { useAuth } from '../services/AuthContext';

const PrivateRoute = ({ element: Element, ...rest }) => {
  const { user } = useAuth();

  // Render the element if the user is authenticated, otherwise redirect to login
  return user ? <Element {...rest} /> : <Navigate to="/loginform" replace />;
};

export default PrivateRoute;
