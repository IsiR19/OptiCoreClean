import React, { createContext, useState, useContext } from 'react'

const AuthContext = createContext()

export const useAuth = () => useContext(AuthContext)
export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null)
  const [error, setError] = useState(null)

  const login = async (userData) => {
    try {
      const response = await fetch('localhost auth endpoint', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(userData),
      })

      if (!response.ok) {
        throw new Error('Invalid username or password')
      }

      const sessionResponse = await response.json()
      setUser(sessionResponse.user)
      setError(null)
    } catch (error) {
      setError(error.message)
    }
  }

  const logout = () => {
    setUser(null)
  }

  return (
    <AuthContext.Provider value={{ user, error, login, logout }}>
      {children}
    </AuthContext.Provider>
  )
}
