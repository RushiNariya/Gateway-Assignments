import "./App.css";
import Dashboard from "./Components/Dashboard";
import { BrowserRouter, Route, Switch } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <Switch>
          <Route path="*" component={Dashboard} />
        </Switch>
      </div>
    </BrowserRouter>
  );
}

export default App;
