import React from "react";
import { Transaction } from "./Transaction";
import { useFetchTransactionsForAccount } from "../../../api/useApiFetch";

type TransactionListProps = {
  accountId: string;
};

export const TransactionList = ({ accountId }: TransactionListProps) => {
  const _transactions = useFetchTransactionsForAccount(accountId);

  const transactions = _transactions.map((transaction, i) => (
    <Transaction transaction={transaction} key={i} />
  ));

  return (
    <>
      <strong>Transaksjoner</strong>
      {transactions}
    </>
  );
};
