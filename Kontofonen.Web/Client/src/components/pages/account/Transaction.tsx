import React from "react";
import { Transaction as TransactionType } from "../../../../types/types";
import { Row, Col } from "reactstrap";

type TransactionProps = {
  transaction: TransactionType;
};

export const Transaction = ({ transaction }: TransactionProps) => (
  <Row>
    <Col>{transaction.description}</Col>
    <Col>{transaction.amount.amount}</Col>
  </Row>
);
