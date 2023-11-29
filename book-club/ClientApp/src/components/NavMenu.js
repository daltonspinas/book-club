import React, { Component, useContext, useState } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { AppContext } from '../context/GlobalState';


export function NavMenu(props) {

  const {pageTitle, setPageTitle} = useContext(AppContext);
  const [collapsed, setCollapsed] = useState('');

  function toggleNavbar() {
    setCollapsed(!collapsed);
  }

  return (
    <header>
         <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
           <NavbarBrand tag={Link} to="/">{pageTitle}</NavbarBrand>
           <NavbarToggler onClick={toggleNavbar} className="mr-2" />
           <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
             <ul className="navbar-nav flex-grow">
               <NavItem>
                 <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
               </NavItem>
               <NavItem>
                 <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
               </NavItem>
               <NavItem>
                 <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
               </NavItem>
               <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/login-signup">Login/SignUp</NavLink>
               </NavItem>
             </ul>
           </Collapse>
         </Navbar>
       </header>
  )
}
