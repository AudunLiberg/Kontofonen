import React, { Component, Suspense } from "react";
import { AccountsList } from "./AccountsList";
import { Spinner } from "../../common/spinner/Spinner";

export class AccountsPage extends Component {
  render() {
    return (
      <>
        <Suspense fallback={<Spinner entityName={"kontoer"} />}>
          Dette er dine kontoer:
          <AccountsList />
        </Suspense>
      </>
    );
  }
}
