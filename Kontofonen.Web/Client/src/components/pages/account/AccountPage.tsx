import React, { Suspense } from "react";
import { Spinner } from "../../common/spinner/Spinner";
import { RouteComponentProps } from "react-router-dom";
import { TransactionList } from "./TransactionList";
import { AccountDetails } from "./AccountDetails";

interface RouteParams {
  accountId: string;
}

type Props = RouteComponentProps<RouteParams>;

export const AccountPage: React.FC<Props> = props => {
  const accountId = props.match.params.accountId;

  return (
    <>
      <Suspense fallback={<Spinner entityName={"konto"} />}>
        <AccountDetails accountId={accountId} />
        <TransactionList accountId={accountId} />
      </Suspense>
    </>
  );
};
