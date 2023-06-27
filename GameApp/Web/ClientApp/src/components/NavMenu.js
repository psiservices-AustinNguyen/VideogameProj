import React from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

const NavMenu = () => {
  //static displayName = NavMenu.name;

  //constructor (props) {
  //  super(props);

  //  this.toggleNavbar = this.toggleNavbar.bind(this);
  //  this.state = {
  //    collapsed: true
  //  };
  //}

  //toggleNavbar () {
  //  this.setState({
  //    collapsed: !this.state.collapsed
  //  });
  //}

    return (
      <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm bg-white border-bottom box-shadow mb-3" container light>
          <NavbarBrand tag={Link} to="/">Videogames</NavbarBrand>
          <NavbarToggler className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse"  navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/DevCompanies">Companies</NavLink>
              </NavItem>
            </ul>
          </Collapse>
        </Navbar>
      </header>
    );
 
}

export default NavMenu;