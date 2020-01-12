import React, { Component } from "react";

export class HomePage extends Component {
  static displayName = HomePage.name;

  render() {
    return (
      <div>
        <h1>Kontofonen, en SpareBank1-integrasjon</h1>
        <ul>
          <li>
            <a href="https://get.asp.net/">ASP.NET Core</a> og{" "}
            <a href="https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx">
              C#
            </a>{" "}
            på serverside.
          </li>
          <li>
            <a href="https://facebook.github.io/react/">React</a> med{" "}
            <a href="https://www.typescriptlang.org/">TypeScript</a> på
            klientside.
          </li>
          <li>
            <a href="http://getbootstrap.com/">Bootstrap</a> til layouten.
          </li>
        </ul>
      </div>
    );
  }
}
