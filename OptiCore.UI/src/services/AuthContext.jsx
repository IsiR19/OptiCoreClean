import { createContext, useState, useContext } from 'react';
import useRunOnce from '../hooks/runOnce';
import config from '../config';
import {
  googlePopup,
  onAuthStateChanged,
  signInWithEmailAndPassword,
  signOut,
} from './firebase';
import axios from 'axios';
const AuthContext = createContext();

// eslint-disable-next-line react-refresh/only-export-components
export const useAuth = () => useContext(AuthContext);
// eslint-disable-next-line react/prop-types
export const AuthProvider = ({ children }) => {
  axios.defaults.headers.post['Content-Type'] = 'application/json;charset=utf-8';
  axios.defaults.withCredentials = true;
  const [user, setUser] = useState(null);
  const [error, setError] = useState(null);
  const [isManual, setIsManual] = useState(false);
  const [hasSession, setHasSession] = useState(false);
  const [isLoading, setIsLoading] = useState(true);
  const sessionEndpoint = `${config.apiBase}session`;
  useRunOnce({
    fn: () => {
      onAuthStateChanged(handleAuthStateChange);
    },
  });

  const handleAuthStateChange = (stateUser) => {
    console.warn('DEBUG onAuthStateChanged', {
      stateUser,
      isManual,
      sessionUser: user,
    });
    if (!stateUser && !!user) {
      logout();
      setIsLoading(false);
      return;
    }
    if (!stateUser) {
      setIsLoading(false);
      return;
    }
    if (isManual) {
      setIsManual(false);
      setIsLoading(false);
      return;
    }
    startSession(stateUser).then((success) => {
      if (!success) {
        //logout() // <---- Uncomment this after auth testing
      }
      setIsLoading(false);
    });
  };
  const login = (userData) => {
    setIsManual(true);
    signInWithEmailAndPassword(userData.email, userData.password)
      .then((googleCredentials) => {
        if (googleCredentials.user) {
          startSession(googleCredentials.user);
        }
      })
      .catch((e) => {
        console.error(e);
      });
  };

  const logout = async () => {
    await signOut();
    await endSession();
    setUser(null);
  };

  const oauthLogin = async () => {
    try {
      setIsManual(true);
      const popupResult = await googlePopup();
      if (!popupResult.user) {
        return false;
      }
      setUser(popupResult.user);
      return await startSession(popupResult.user);
    } catch (error) {
      setError(error);
      console.error(error);
    }
  };

  const startSession = async (googleUser) => {
    try {
      const accessToken = googleUser.accessToken;
      const response = await axios.get(`${sessionEndpoint}/google/start`, {
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${accessToken}`,
        },
      });
      if (response.status !== 200) {
        throw new Error(
          'Something went wrong trying to start your session: ' +
            response.message,
        );
      }
      setError(null);
      setHasSession(true);
      setUser(googleUser);
      return true;
    } catch (error) {
      setError(error.message);
      console.error('startSession', error);
      return false;
    }
  };

  const endSession = async () => {
    try {
      if (!hasSession) {
        return;
      }
      const response = await fetch(`${sessionEndpoint}/end`, {
        method: 'DELETE',
      });

      if (!response.ok) {
        throw new Error('Something went wrong trying to end your session');
      }
      setUser(null);
      setError(null);
      setIsManual(true);
      setHasSession(false);
    } catch (error) {
      setError(error.message);
    }
  };

  return (
    <AuthContext.Provider value={{ user, error, login, oauthLogin, logout, isLoading }}>
      {children}
    </AuthContext.Provider>
  );
};
