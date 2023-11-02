import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { users: [], loading: true };
  }

  componentDidMount() {
    this.populateUserData();
  }

    static renderUsersTable(users) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Email</th>
            <th>Username</th>
            <th>Password</th>
          </tr>
        </thead>
        <tbody>
          {users.map(user =>
            <tr key={user.userId}>
              <td>{user.email}</td>
              <td>{user.username}</td>
              <td>{user.password}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : FetchData.renderUsersTable(this.state.users);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

    async populateUserData() {
    const response = await fetch('api/user');
    const data = await response.json();
    this.setState({ users: data, loading: false });
  }
}
