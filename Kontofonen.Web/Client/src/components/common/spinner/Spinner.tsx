import React from "react";
import reactLogo from "./react-logo.svg";
import "./Spinner.css";

type SpinnerProps = {
  entityName: string;
};

export const Spinner = ({ entityName }: SpinnerProps) => {
  return (
    <div>
      <img src={reactLogo} className="Spinning-image" alt="" />
      Laster inn {entityName} …
    </div>
  );
};
