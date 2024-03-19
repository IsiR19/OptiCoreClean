import React from 'react';
import { Navbar, Container, Nav } from 'react-bootstrap';
import { BsFillBellFill, BsFillEnvelopeFill, BsPersonCircle, BsSearch, BsJustify } from 'react-icons/bs';
import './Header.scss'; // Make sure to create a Header.scss file with the styles

function Header({ OpenSidebar }) {
  return (
    <Navbar expand="lg" variant="light" className="header">
      <Container fluid>
        <Nav.Link onClick={OpenSidebar} className="menu-icon">
          <BsJustify />
        </Nav.Link>
        <Navbar.Brand href="#home" className="header-left">
          <BsSearch />
        </Navbar.Brand>
        <Nav className="header-right">
          <Nav.Link href="#notifications">
            <BsFillBellFill />
          </Nav.Link>
          <Nav.Link href="#messages">
            <BsFillEnvelopeFill />
          </Nav.Link>
          <Nav.Link href="#profile">
            <BsPersonCircle />
          </Nav.Link>
        </Nav>
      </Container>
    </Navbar>
  );
}

export default Header;
