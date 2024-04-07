import { createContext, useState, useContext, useCallback } from 'react';
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

export const useAuth = () => useContext(AuthContext);

export const AuthProvider = ({ children }) => {
  axios.defaults.headers.post['Content-Type'] = 'application/json;charset=utf-8';
  axios.defaults.withCredentials = true;
  const [user, setUser] = useState(null);
  const [error, setError] = useState(null);
  const [isManual, setIsManual] = useState(false);
  const [hasSession, setHasSession] = useState(false);
  const [isLoading, setIsLoading] = useState(true);
  const sessionEndpoint = `${config.apiBase}session`;

  const startSession = useCallback(async (googleUser) => {
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
  }, []);

  const endSession = useCallback(async () => {
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
      setIsManual(false);
      setHasSession(false);
    } catch (error) {
      setError(error.message);
      console.error(error);
    }
  }, [hasSession]);

  const logout = useCallback(async () => {
    try {
      await signOut();
      await endSession();
      setUser(null);
      setIsLoading(false);
    } catch (e) {
      console.error(e);
      setError(e.message);
    }
  }, [endSession]);

  const handleAuthStateChange = useCallback((stateUser) => {
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
    if (!stateUser || isManual) {
      setIsLoading(false);
      return;
    }
    startSession(stateUser).then((success) => {
      if (!success) {
        //logout() // Uncomment this after auth testing
      }
      setIsLoading(false);
    });
  }, [user, logout, startSession, isManual]);

  useRunOnce({
    fn: handleAuthStateChange,
  });

  const login = useCallback(async (userData) => {
    setIsManual(true);
    try {
      const googleCredentials = await signInWithEmailAndPassword(userData.username, userData.password);
      if (googleCredentials.user) {
        await startSession(googleCredentials.user);
      }
    } catch (e) {
      console.error(e);
      setError(e.message);
    } finally {
      setIsLoading(false);
    }
  }, [startSession]);

  const oauthLogin = useCallback(async () => {
    setIsManual(true);
    try {
      const popupResult = await googlePopup();
      if (!popupResult.user) {
        return false;
      }
      await startSession(popupResult.user);
    } catch (e) {
      console.error(e);
      setError(e.message);
    } finally {
      setIsLoading(false);
    }
  }, [startSession]);

  return (
    <AuthContext.Provider value={{ user, error, login, oauthLogin, logout, isLoading }}>
      {children}
    </AuthContext.Provider>
  );
};
