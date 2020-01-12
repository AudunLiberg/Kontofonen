import useFetch from "fetch-suspense";
import { Accounts as AccountsType } from "../../types/types";

const baseUrl = window.location.origin + "/api/";

function useFetchType<T>(url: string) {
  const serverResponse = useFetch(baseUrl + url, { method: "GET" });
  return serverResponse.valueOf() as T;
}

function useFetchAccounts() {
  return useFetchType<AccountsType>("account");
}

export { useFetchAccounts };
