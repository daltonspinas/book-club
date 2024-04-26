import React, { Component, useContext, useState } from "react";
import {
  Collapse,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
} from "reactstrap";
import { Link, useNavigate } from "react-router-dom";
import "./NavMenu.css";
import { AppContext } from "../context/GlobalContext";
import { AppUserContext } from "../context/UserContext";
import { userAPI } from "../API/Controllers/User";

export function NavMenu(props) {
  const navigate = useNavigate();

  const { pageTitle, setPageTitle } = useContext(AppContext);
  const { appUser, setAppUser } = useContext(AppUserContext);
  const [collapsed, setCollapsed] = useState(false);

  async function handleLogout() {
    if(!appUser) return;
    userAPI.logout().then((data) => {
      localStorage.removeItem('accessToken')
      setAppUser(null);
      navigate("/");
    });
  }

  function toggleNavbar() {
    setCollapsed(!collapsed);
  }

  return (
    <header>
      <Navbar
        className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
        container
        light
      >
        <NavbarBrand tag={Link} to="/">
          {pageTitle}
        </NavbarBrand>
        <NavbarToggler onClick={toggleNavbar} className="mr-2" />
        <Collapse
          className="d-sm-inline-flex flex-sm-row-reverse"
          isOpen={!collapsed}
          navbar
        >
          <ul className="navbar-nav flex-grow">
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/">
                Home
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/counter">
                Counter
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/fetch-data">
                Fetch data
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink
                tag={Link}
                className="text-dark"
                to={!appUser ? "/login-signup" : ""}
                onClick={handleLogout}
              >
                {appUser ? "Logout" : "Login/Signup"}
              </NavLink>
            </NavItem>
          </ul>
        </Collapse>
      </Navbar>
    </header>
  );
}
