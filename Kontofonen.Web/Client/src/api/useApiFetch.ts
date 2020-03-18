import useFetch from "fetch-suspense";
import {
  Accounts as AccountsType,
  Account as AccountType,
  Transactions as TransactionsType
} from "../../types/types";

const baseUrl = window.location.origin + "/api/";

function useFetchType<T>(url: string) {
  const serverResponse = useFetch(baseUrl + url, { method: "GET" });
  return serverResponse.valueOf() as T;
}

function useFetchAccounts() {
  return useFetchType<AccountsType>("account");
}

function useFetchAccount(accountId: string) {
  return useFetchType<AccountType>(`account/${accountId}`);
}

function useFetchTransactionsForAccount(accountId: string) {
  return useFetchType<TransactionsType>(`account/${accountId}/transactions`)
    .transactions;
}

export { useFetchAccounts, useFetchAccount, useFetchTransactionsForAccount };
