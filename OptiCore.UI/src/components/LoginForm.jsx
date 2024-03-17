import React from 'react';
import { useNavigate } from 'react-router-dom';
import { GoogleLogin } from 'react-google-login';
import axios from 'axios';
import { Container, Row, Col } from 'react-bootstrap';

function LoginForm() {
  const navigate = useNavigate();

  const handleLogin = async (googleData) => {
    try {
      const response = await axios.post('need to place Auth Service URL here', {
        token: googleData.tokenId,
      });

      localStorage.setItem('token', response.data.token);
      // Redirect to the home page or dashboard
      navigate('/home');
    } catch (error) {
      console.error('Login failed', error);
    }
  };

  const handleFailure = (error) => {
    console.error('Google Login Failure', error);
  };

  return (
    <Container>
      <Row className="justify-content-md-center">
        <Col md="6">
          <h2>Login</h2>
          <GoogleLogin
            clientId="your-google-client-id"
            buttonText="Login with Google"
            onSuccess={handleLogin}
            onFailure={handleFailure}
            cookiePolicy={'single_host_origin'}
          />
        </Col>
      </Row>
    </Container>
  );
}

export default LoginForm;
