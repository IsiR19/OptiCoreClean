import { useState } from 'react'
import './App.css'
import Header from './components/Header'
import Sidebar from './components/Sidebar'
import Home from './components/Home'

function App() {
  const[openSidebarToggle,setOpenSidebarToggle] =useState(false)

  const openSidebar = () =>{
    setOpenSidebarToggle(!openSidebarToggle)
  }
  return (
 <div className='grid-container'>
  <Header OpenSidebar={openSidebar} />
  <Sidebar openSidebarToggle={openSidebarToggle} openSidebar={openSidebar} />
  <Home />
 </div>
  )
}

export default App
