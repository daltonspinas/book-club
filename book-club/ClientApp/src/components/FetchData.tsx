import React, { Component } from 'react';
import { userAPI } from '../API/Controllers/User';

export class FetchData extends Component<any, any> {
  static displayName = FetchData.name;

  constructor(props: {users: [], loading: boolean}) {
    super(props);
    this.state = { users: [], loading: true };
  }

  componentDidMount() {
    this.populateUserData();
  }

    static renderUsersTable(users: {id: string, email: string, userName: string, password: string}[]) {
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
            <tr key={user.id}>
              <td>{user.email}</td>
              <td>{user.userName}</td>
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
        <h1 id="tabelLabel" >Users</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

    populateUserData() {
    userAPI.getAll().then(data => {
      this.setState({users: data, loading: false})
    })
  }
}
