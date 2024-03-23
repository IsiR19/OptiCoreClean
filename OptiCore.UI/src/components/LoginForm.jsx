import  { useState } from 'react';
import { useAuth } from '../services/AuthContext';

const LoginForm = () => {
  const { login, oauthLogin, logout } = useAuth();
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const handleSubmit = async (e) => {
    e.preventDefault();

    await login({ username, password });

    setUsername('');
    setPassword('');
  };

  const handleGoogleSignIn = () => oauthLogin();

  return (
    <div className="container">
      <h2>Login</h2>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label htmlFor="username" className="form-label">
            Username
          </label>
          <input
            type="text"
            className="form-control"
            id="username"
            placeholder="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>
        <div className="mb-3">
          <label htmlFor="password" className="form-label">
            Password
          </label>
          <input
            type="password"
            className="form-control"
            id="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <button type="submit" className="btn btn-primary">
          Login
        </button>
        <div className="row login-controls">
          <div className="col-12">
            <img
              className="google-button"
              alt="Google sign in"
              onClick={handleGoogleSignIn}
            />
          </div>
        </div>
      </form>
      <button className="btn btn-primary" onClick={logout}>
        Logout
      </button>
    </div>
  );
};

export default LoginForm;
