import React from "react";
import { useFetchAccount } from "../../../api/useApiFetch";

type AccountDetailsProps = {
  accountId: string;
};

export const AccountDetails = ({ accountId }: AccountDetailsProps) => {
  const account = useFetchAccount(accountId);

  return (
    <p>
      <strong>Konto:</strong> {account.name}
      <br />
      <strong>Saldo:</strong> {account.balance.amount}
      <br />
      <strong>Rente:</strong> {account.interestRate} %
    </p>
  );
};
