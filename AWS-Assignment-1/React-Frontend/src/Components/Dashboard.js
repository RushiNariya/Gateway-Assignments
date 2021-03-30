import React, { useEffect } from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router";
import HeaderDashboard from "./HeaderDashboard/HeaderDashboard";
import Main from "./Main/Main";
import "./css/Dashboard.css";

function Dashboard() {
  return (
    <div id="page-top">
      <div id="wrapper">
        <HeaderDashboard />
        <div id="content-wrapper" className="d-flex flex-column">
          <Main />
        </div>
      </div>
    </div>
  );
}

export default Dashboard;
