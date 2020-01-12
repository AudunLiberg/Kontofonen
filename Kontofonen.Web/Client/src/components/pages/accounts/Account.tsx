import React from "react";
import { Account as AccountType } from "../../../../types/types";

type AccountProps = {
  account: AccountType;
};

export const Account = ({ account }: AccountProps) => (
  <>
    <h2>{account.name}</h2>
    <p>Saldo: {account.balance.amount}</p>
  </>
);
