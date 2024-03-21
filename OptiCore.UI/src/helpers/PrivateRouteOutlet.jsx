import React from 'react'
import { Route, Navigate, Outlet } from 'react-router-dom'
import { useAuth } from '../services/AuthContext'

const PrivateRouteOutlet = () => {
  const { user } = useAuth()
  console.error('DEBUG PrivateRouteOutlet')
  const outlet = !!user? <Outlet/>:<Navigate to={'/login'} />
  console.error('DEBUG PrivateRouteOutlet result', outlet)
  return outlet
}

export default PrivateRouteOutlet
