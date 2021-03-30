import React from "react";
import { NavLink } from "react-router-dom";

import "./HeaderDashboard.css";

function HeaderDashboard() {
  return (
    <ul
      className="navbar-nav sidebar sidebar-dark accordion"
      id="accordionSidebar"
    >
      <div className="navbar-container">
        <a
          href="/"
          className="sidebar-brand d-flex align-items-center justify-content-center"
        >
          <div className="sidebar-brand-text mx-3">AWS</div>
        </a>

        <hr className="sidebar-divider my-0" />

        <hr className="sidebar-divider my-0" />

        <li className="nav-item">
          <NavLink
            activeStyle={{ color: "#fff" }}
            to="/customers"
            className="nav-link Navlink"
            exact
          >
            <i className="fab fa-wpforms fontawesome"></i>
            <span className="names">Users</span>
          </NavLink>
        </li>

        <hr className="sidebar-divider my-0" />

        <li className="nav-item">
          <NavLink
            activeStyle={{ color: "#fff" }}
            to="/addcustomer"
            className="nav-link Navlink"
            exact
          >
            <i className="far fa-plus-square fontawesome"></i>
            <span className="names">Add User</span>
          </NavLink>
        </li>

        <hr className="sidebar-divider d-none d-md-block" />
      </div>
    </ul>
  );
}

export default HeaderDashboard;
