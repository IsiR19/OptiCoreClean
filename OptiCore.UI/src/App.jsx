import { useState } from 'react'
import './App.css'
import Header from './components/Header'
import Sidebar from './components/Sidebar'
import Home from './components/Home'
import UserForm from './components/UserForm'
import LoginForm from './components/LoginForm'
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom'
import PrivateRouteOutlet from './helpers/PrivateRouteOutlet'
import { AuthProvider } from '../src/services/AuthContext'
import { QueryClient, QueryClientProvider } from '@tanstack/react-query'

function App() {
  const [openSidebarToggle, setOpenSidebarToggle] = useState(false)
  const queryClient = new QueryClient()
  const openSidebar = () => {
    setOpenSidebarToggle(!openSidebarToggle)
  }

  return (
    <QueryClientProvider client={queryClient}>
      <Router>
        <AuthProvider>
          <div className="grid-container">
            <Header OpenSidebar={openSidebar} />
            <Sidebar
              openSidebarToggle={openSidebarToggle}
              openSidebar={openSidebar}
            />
            <Routes>
              <Route exact path="/" element={<Home />} />
              <Route exact path="/login" element={<LoginForm />} />
              <Route exact path="/" element={<PrivateRouteOutlet />}>
                {/* <Route path="" element={<Home />} /> */}
                <Route
                  path="/users"
                  element={
                    <div className="ml-5">
                      <UserForm />
                    </div>
                  }
                />
              </Route>
            </Routes>
          </div>
        </AuthProvider>
      </Router>
    </QueryClientProvider>
  )
}

export default App
