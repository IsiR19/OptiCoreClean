import React, { createContext, useState, useContext, useEffect } from 'react'
import config from '../config'
import {
  googlePopup,
  onAuthStateChanged,
  signInWithEmailAndPassword,
} from './firebase'

const AuthContext = createContext()

export const useAuth = () => useContext(AuthContext)
export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null)
  const [error, setError] = useState(null)
  const [isManual, setIsManual] = useState(false)
  const sessionEndpoint = `${config.apiBase}session`
  useEffect(() => {
    onAuthStateChanged((stateUser) => {
      if (!stateUser && !!user) {
        endSession()
        return
      }
      if (isManual) {
        return
      }
      startSession(stateUser)
    })
  })
  const login = (userData) => {
    setIsManual(true)
    signInWithEmailAndPassword(userData.email, userData.password).then(
      (googleCredentials) => {
        if (googleCredentials.user) {
          startSession(googleCredentials.user)
          googleCredentials.user.getIdToken()
        }
      },
    )
  }

  const logout = async () => {
    setUser(null)
  }

  const oauthLogin = () => {
    setIsManual(true)
    googlePopup().then((googleCredentials) => {
      if (googleCredentials.user) {
        startSession(googleCredentials.user)
        googleCredentials.user.getIdToken()
      }
    })
  }

  const startSession = async (googleUser) => {
    try {
      const response = await fetch(`${sessionEndpoint}/google/start`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${googleUser.getIdToken()}`,
        },
      })

      if (!response.ok) {
        throw new Error('Something went wrong trying to start your session')
      }
      setUser(googleUser)
      setError(null)
      setIsManual(false)
    } catch (error) {
      setError(error.message)
    }
  }

  const endSession = async () => {
    try {
      const response = await fetch(`${sessionEndpoint}/end`, {
        method: 'DELETE',
      })

      if (!response.ok) {
        throw new Error('Something went wrong trying to end your session')
      }
      setUser(null)
      setError(null)
      setIsManual(true)
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
