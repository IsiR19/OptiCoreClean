import React from 'react';
import { BsFillBellFill, BsFillEnvelopeFill, BsPersonCircle, BsSearch, BsJustify } from 'react-icons/bs';
import { Link } from 'react-router-dom';

function Header({ OpenSidebar }) {
  return (
    <header className='d-flex justify-content-between align-items-center px-3 py-2 shadow' style={{ backgroundColor: '#263043', color: '#9e9ea4' }}>
      <div className='menu-icon d-md-none'>
        <BsJustify className='icon' onClick={OpenSidebar} style={{ cursor: 'pointer' }} />
      </div>
      <div className='header-left d-none d-md-flex'>
        <BsSearch className='icon' />
      </div>
      <div className='header-right'>
        <Link to="/notifications" className="text-secondary me-3">
          <BsFillBellFill className='icon' />
        </Link>
        <Link to="/messages" className="text-secondary me-3">
          <BsFillEnvelopeFill className='icon' />
        </Link>
        <Link to="/profile" className="text-secondary">
          <BsPersonCircle className='icon' />
        </Link>
      </div>
    </header>
  );
}

export default Header;
