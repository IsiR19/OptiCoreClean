import React from 'react'
import { Navigate, Outlet, useLocation } from 'react-router-dom'
import { useAuth } from '../services/AuthContext'

const PrivateRouteOutlet = () => {
  const { user } = useAuth()
  const location = useLocation()
  const original = location.pathname;
  const outlet = !!user ? <Outlet /> : <Navigate state={original} to={'/login'} replace={true} />
  return outlet
}

export default PrivateRouteOutlet
