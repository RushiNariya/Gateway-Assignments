import React from "react";
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";

import StickyTop from "./StickyTop/StickyTop";
import "./Main.css";

import Welcome from "../Welcome/Welcome";
import Customer from "../Customer/Customer";
import AddCustomer from "../Customer/AddCustomer";

function Main() {
  return (
    <div id="content">
      <StickyTop />
      <div className="main m-auto">
        <Route path="/" exact component={Welcome} />
        <Route path="/customers" exact component={Customer} />
        <Route path="/addcustomer" exact component={AddCustomer} />
      </div>
    </div>
  );
}

export default Main;
