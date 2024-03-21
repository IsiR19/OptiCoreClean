import secrets from './secrets/secrets.json'
const config = {
  ...secrets,
  apiBase: process.env.REACT_APP_API_BASE,
}
export default config
