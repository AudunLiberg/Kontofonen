import React from "react";
import { Account } from "./Account";
import { useFetchAccounts } from "../../../api/useApiFetch";

export const AccountsList = () => {
  const data = useFetchAccounts();

  const listItems = data.accounts.map(account => (
    <Account account={account} key={account.id} />
  ));

  return <>{listItems}</>;
};
