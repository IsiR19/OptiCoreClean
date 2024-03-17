import React from 'react'
import {BsCart3,BsFillHddFill,BsFillArchiveFill,BsFillGrid3X3GapFill,BsPeopleFill
,BsListCheck,BsPersonBadge ,BsFillGearFill,BsPhoneVibrate,BsHeadset,BsFillPersonLinesFill   } from 'react-icons/bs'

function Sidebar({openSidebarToggle,OpenSidebar}) {
  return (
   <aside id="sidebar" className={openSidebarToggle? "sidebar-responsive":""}>
    <div className='sidebar-title'>
        <div className='sidebar-brand'>
            <BsFillHddFill className='icon_header' /> Godlela
        </div>
        <span className='icon close_icon' onClick={OpenSidebar}>X</span>
    </div>

    <ul className='sidebar-list'>
        <li className='sidebar-list-item'>
            <a href="">
                <BsFillGrid3X3GapFill className='icon' /> Dashboard
            </a>
        </li>
        <li className='sidebar-list-item'>
            <a href="">
                <BsPhoneVibrate className='icon' /> Leads
            </a>
        </li>
        <li className='sidebar-list-item'>
            <a href="">
                <BsFillArchiveFill className='icon' /> Products
            </a>
        </li>
        <li className='sidebar-list-item'>
            <a href="">
                <BsHeadset  className='icon' /> Agents
            </a>
        </li>
        <li className='sidebar-list-item'>
            <a href="">
                <BsFillPersonLinesFill className='icon' /> Channel Partners
            </a>
        </li>
        <li className='sidebar-list-item'>
            <a href="">
                <BsPeopleFill className='icon' /> Customers
            </a>
        </li>
        <li className='sidebar-list-item'>
            <a href="">
                <BsListCheck className='icon' /> Reports
            </a>
        </li>
        <li className='sidebar-list-item'>
            <a href="">
                <BsPersonBadge  className='icon' /> Users
            </a>
        </li>
        <li className='sidebar-list-item'>
            <a href="">
                <BsFillGearFill className='icon' /> Settings
            </a>
        </li>
    </ul>
   </aside>
  )
}

export default Sidebar
