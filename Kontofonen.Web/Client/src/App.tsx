import React from "react";
import { Layout } from "./components/layout/Layout";
import { HomePage } from "./components/pages/home/HomePage";
import { AccountsPage } from "./components/pages/accounts/AccountsPage";
import { Route, Switch } from "react-router";
import { BrowserRouter } from "react-router-dom";

const App = () => {
  return (
    <BrowserRouter>
      <Layout>
        <Switch>
          <Route path="/accounts" component={AccountsPage} />
          <Route component={HomePage} />
        </Switch>
      </Layout>
    </BrowserRouter>
  );
};

export default App;
