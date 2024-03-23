import React, { createContext, useState, useContext, useEffect } from 'react'
import useRunOnce from '../hooks/runOnce'
import config from '../config'
import {
  googlePopup,
  onAuthStateChanged,
  signInWithEmailAndPassword,
  signOut,
  firebase,
} from './firebase'
import axios from 'axios'
const AuthContext = createContext()

export const useAuth = () => useContext(AuthContext)
export const AuthProvider = ({ children }) => {
  axios.defaults.headers.post['Content-Type'] = 'application/json;charset=utf-8'
  axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*'
  axios.defaults.withCredentials = false
  const [user, setUser] = useState(null)
  const [error, setError] = useState(null)
  const [isManual, setIsManual] = useState(false)
  const [hasSession, setHasSession] = useState(false)
  const sessionEndpoint = `${config.apiBase}session`
  useRunOnce({
    fn: () => {
      onAuthStateChanged(handleAuthStateChange)
    },
  })

  const handleAuthStateChange = (stateUser) => {
    console.warn('DEBUG onAuthStateChanged', {
      stateUser,
      isManual,
      sessionUser: user,
    })
    if (!stateUser && !!user) {
      logout()
      return
    }
    if (!stateUser) {
      return
    }
    if (isManual) {
      setIsManual(false)
      return
    }
    startSession(stateUser).then((success) => {
      if (!success) {
        logout()
      }
    })
  }
  const login = (userData) => {
    setIsManual(true)
    signInWithEmailAndPassword(userData.email, userData.password)
      .then((googleCredentials) => {
        if (googleCredentials.user) {
          startSession(googleCredentials.user)
        }
      })
      .catch((e) => {
        console.error(e)
      })
  }

  const logout = async () => {
    await signOut()
    await endSession()
    setUser(null)
  }

  const oauthLogin = async () => {
    try {
      setIsManual(true)
      const popupResult = await googlePopup()
      if (!popupResult.user) {
        return false
      }
      setUser(popupResult.user)

      return await startSession(popupResult.user)
    } catch (error) {
      setError(error)
      console.error(error)
    }
  }

  const startSession = async (googleUser) => {
    try {
      const idToken = await googleUser.getIdToken()
      const accessToken = googleUser.accessToken
      const response = await axios.get(`${sessionEndpoint}/google/start`, {
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${accessToken}`,
        },
      })
      // const response = await fetch(`${sessionEndpoint}/google/start`, {
      //   method: 'GET',
      //   headers: {
      //     'Content-Type': 'application/json',
      //     Authorization: `Bearer ${idToken}`,
      //   },
      // })
      if (!response.status !== 200) {
        throw new Error('Something went wrong trying to start your session')
      }
      setError(null)
      setHasSession(true)
      return true
    } catch (error) {
      setError(error.message)
      console.error('startSession', error)
      return false
    }
  }

  const endSession = async () => {
    try {
      if (!hasSession) {
        return
      }
      console.warn('DEBUG endSession')
      const response = await fetch(`${sessionEndpoint}/end`, {
        method: 'DELETE',
      })

      if (!response.ok) {
        throw new Error('Something went wrong trying to end your session')
      }
      setUser(null)
      setError(null)
      setIsManual(true)
      setHasSession(false)
    } catch (error) {
      setError(error.message)
    }
  }

  return (
    <AuthContext.Provider value={{ user, error, login, oauthLogin, logout }}>
      {children}
    </AuthContext.Provider>
  )
}
