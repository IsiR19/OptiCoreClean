import { Outlet } from 'react-router-dom';
import { useAuth } from '../services/AuthContext';
import LoginForm from '../components/LoginForm';

const PrivateRouteOutlet = () => {
  const { user,company, isLoading } = useAuth();
  const tempLoadingComponent = <h2>Loading...</h2>; //TODO: Replace this with actual loader
  let outlet = tempLoadingComponent;
  if (!isLoading) {
      outlet = user ? <Outlet /> : <LoginForm />;
      outlet = company ? <Outlet /> : <LoginForm />;
  }
  return outlet;
};

export default PrivateRouteOutlet;
