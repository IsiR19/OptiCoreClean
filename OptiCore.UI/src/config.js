 
import secrets from './secrets/secrets.json';
const config = {
  ...secrets,
  apiBase: process.env.REACT_APP_API_BASE ?? 'https://localhost:7261/api/',
};
export default config;
