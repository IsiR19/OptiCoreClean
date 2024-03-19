import React from 'react';
import { BsFillBellFill, BsFillEnvelopeFill, BsPersonCircle, BsSearch, BsJustify } from 'react-icons/bs';

function Header({ OpenSidebar }) {
  return (
    <header className='d-flex justify-content-between align-items-center px-3 py-2 shadow' style={{ backgroundColor: '#263043', color: '#9e9ea4' }}>
      <div className='menu-icon d-md-none'>
        <BsJustify className='icon' onClick={OpenSidebar} style={{ cursor: 'pointer' }} />
      </div>
      <div className='header-left d-none d-md-flex'>
        <BsSearch className='icon' />
      </div>
      <div className='header-right d-flex align-items-center'>
        <BsFillBellFill className='icon text-secondary me-3'/>
        <BsFillEnvelopeFill className='icon text-secondary me-3'/>
        <BsPersonCircle className='icon text-secondary'/>
      </div>
    </header>
  );
}

export default Header;
