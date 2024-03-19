import { useState } from 'react'
import './App.css'
import Header from './components/Header'
import Sidebar from './components/Sidebar'
import Home from './components/Home'
import UserForm from './components/UserForm'
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom'
import { AuthProvider } from '../src/services/AuthContext' // Import the AuthProvider component

function App() {
  const [openSidebarToggle, setOpenSidebarToggle] = useState(false)

  const openSidebar = () => {
    setOpenSidebarToggle(!openSidebarToggle)
  }

  return (
    <Router>
      <AuthProvider> 
        <div className='grid-container'>
          <Header OpenSidebar={openSidebar} />
          <Sidebar openSidebarToggle={openSidebarToggle} openSidebar={openSidebar} />
          <Routes>
            <Route exact path="/" element={<Home />} />
            <PrivateRoute path="/users" element={<UserForm />} />
            {/* <Route path="/users" element={
              <div className='ml-5'>
                <UserForm />
              </div>
            } /> */}
          </Routes>
        </div>
      </AuthProvider>
    </Router>
  )
}

export default App
