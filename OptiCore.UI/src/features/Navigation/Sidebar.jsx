import React from 'react';
import { Link } from 'react-router-dom';
import { BsFillGrid3X3GapFill, BsPhoneVibrate, BsFillArchiveFill, BsHeadset, BsFillPersonLinesFill, BsPeopleFill, BsListCheck, BsPersonBadge, BsFillGearFill,BsBuildings} from 'react-icons/bs';

function Sidebar({ openSidebarToggle, OpenSidebar }) {
  // Determine the class to apply based on whether the sidebar is open or closed
  const sidebarClass = openSidebarToggle ? 'sidebar-visible' : '';

  return (
    <aside id="sidebar" className={`bg-dark text-white ${sidebarClass}`}>
      <div className='sidebar-title'>
        <div className='d-flex align-items-center'>
          <BsFillGrid3X3GapFill className='icon_header text-primary' />
          <span className='ms-2 font-weight-bold'>Godlela</span>
        </div>
        <button className='close_icon' onClick={OpenSidebar}>
          <span className='text-danger'>X</span>
        </button>
      </div>

      <nav className="sidebar-list">
        <Link className="nav-link text-secondary sidebar-list-item" to="/">
          <BsFillGrid3X3GapFill className='icon' /> Dashboard
        </Link>
        <Link className="nav-link text-secondary sidebar-list-item" to="/leads">
          <BsPhoneVibrate className='icon' /> Leads
        </Link>
        <Link className="nav-link text-secondary sidebar-list-item" to="/products">
          <BsFillArchiveFill className='icon' /> Products
        </Link>
        <Link className="nav-link text-secondary sidebar-list-item" to="/agents">
          <BsHeadset className='icon' /> Agents
        </Link>
        <Link className="nav-link text-secondary sidebar-list-item" to="/companies">
          <BsBuildings className='icon' /> Companies
        </Link>
        <Link className="nav-link text-secondary sidebar-list-item" to="/partners">
          <BsFillPersonLinesFill className='icon' /> Channel Partners
        </Link>
        <Link className="nav-link text-secondary sidebar-list-item" to="/customers">
          <BsPeopleFill className='icon' /> Customers
        </Link>
        <Link className="nav-link text-secondary sidebar-list-item" to="/reports">
          <BsListCheck className='icon' /> Reports
        </Link>
        <Link className="nav-link text-secondary sidebar-list-item" to="/users">
          <BsPersonBadge className='icon' /> Users
        </Link>
        <Link className="nav-link text-secondary sidebar-list-item" to="/settings">
          <BsFillGearFill className='icon' /> Settings
        </Link>
      </nav>
    </aside>
  );
}

export default Sidebar;
