import React, { useState } from 'react';
import { useAuth } from '../services/AuthContext';
import { Button, Form, Input, Grid, Header, Segment } from 'semantic-ui-react';
import 'semantic-ui-css/semantic.min.css';
import '../layout/styles.scss'; // Replace with the actual path to your SCSS file

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
    <Segment className="container" padded="very">
      <Header as="h2" style={{ color: 'black' }}>Login</Header>
      <Form onSubmit={handleSubmit}>
        <Form.Field>
          <label htmlFor="username">Username</label>
          <Input
            id="username"
            placeholder="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </Form.Field>
        <Form.Field>
          <label htmlFor="password">Password</label>
          <Input
            type="password"
            id="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </Form.Field>
        <Grid columns={2} stackable textAlign="center">
          <Grid.Row verticalAlign="middle">
            <Grid.Column>
              <Button type="submit" primary fluid>
                Login
              </Button>
            </Grid.Column>
            <Grid.Column>
              <div className="google-button" onClick={handleGoogleSignIn} />
            </Grid.Column>
          </Grid.Row>
        </Grid>
        <Grid columns={1} stackable textAlign="center">
          <Grid.Row verticalAlign="middle">
            <Grid.Column>
              <Button onClick={logout} color="red" fluid>
                Logout
              </Button>
            </Grid.Column>
          </Grid.Row>
        </Grid>
      </Form> 
    </Segment>
  );
};

export default LoginForm;
