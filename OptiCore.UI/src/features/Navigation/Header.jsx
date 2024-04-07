import React from 'react';
import { Link } from 'react-router-dom';
import { Menu, Icon } from 'semantic-ui-react';

function Header({ OpenSidebar }) {
  return (
    <Menu inverted borderless className="header">
      {/* Burger menu icon for smaller screens */}
      <Menu.Item onClick={OpenSidebar} className="menu-icon">
        <Icon name='sidebar' />
      </Menu.Item>
      {/* Full menu for larger screens */}
      <Menu.Menu position='right'>
        <Menu.Item as={Link} to="/notifications">
          <Icon name='bell outline' />
        </Menu.Item>
        <Menu.Item as={Link} to="/messages">
          <Icon name='envelope outline' />
        </Menu.Item>
        <Menu.Item as={Link} to="/profile">
          <Icon name='user outline' />
        </Menu.Item>
      </Menu.Menu>
    </Menu>
  );
}

export default Header;
