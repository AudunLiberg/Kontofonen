import React from "react";
import { Account as AccountType } from "../../../../types/types";
import { Link } from "react-router-dom";

type AccountProps = {
  account: AccountType;
};

export const Account = ({ account }: AccountProps) => (
  <>
    <h2>
      <Link to={`account/${account.id}`}>{account.name}</Link>
    </h2>
    <p>Saldo: {account.balance.amount}</p>
  </>
);
