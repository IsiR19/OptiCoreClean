import { BsFillGrid3X3GapFill, BsPhoneVibrate, BsFillArchiveFill, BsHeadset, BsFillPersonLinesFill, BsPeopleFill, BsListCheck, BsPersonBadge, BsFillGearFill } from 'react-icons/bs';
import { Link } from 'react-router-dom';

// eslint-disable-next-line react/prop-types
function Sidebar({ openSidebarToggle, OpenSidebar }) {
  return (
    <aside id="sidebar" className={`bg-dark text-white ${openSidebarToggle ? "d-block" : "d-none d-md-block"}`}>
      <div className='d-flex justify-content-between align-items-center p-3 border-bottom border-secondary'>
        <div className='d-flex align-items-center'>
          <BsFillGrid3X3GapFill className='icon_header text-primary' />
          <span className='ms-2 font-weight-bold'>Godlela</span>
        </div>
        <button className='btn btn-dark d-md-none' onClick={OpenSidebar}>
          <span className='text-danger'>X</span>
        </button>
      </div>

      <nav className="flex-column">
        <Link className="nav-link text-secondary" to="/">
          <BsFillGrid3X3GapFill className='icon' /> Dashboard
        </Link>
        <Link className="nav-link text-secondary" to="/leads">
          <BsPhoneVibrate className='icon' /> Leads
        </Link>
        <Link className="nav-link text-secondary" to="/products">
          <BsFillArchiveFill className='icon' /> Products
        </Link>
        <Link className="nav-link text-secondary" to="/agents">
          <BsHeadset className='icon' /> Agents
        </Link>
        <Link className="nav-link text-secondary" to="/partners">
          <BsFillPersonLinesFill className='icon' /> Channel Partners
        </Link>
        <Link className="nav-link text-secondary" to="/customers">
          <BsPeopleFill className='icon' /> Customers
        </Link>
        <Link className="nav-link text-secondary" to="/reports">
          <BsListCheck className='icon' /> Reports
        </Link>
        <Link className="nav-link text-secondary" to="/users">
          <BsPersonBadge className='icon' /> Users
        </Link>
        <Link className="nav-link text-secondary" to="/settings">
          <BsFillGearFill className='icon' /> Settings
        </Link>
      </nav>
    </aside>
  );
}

export default Sidebar;
