import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { ClubSidebar } from './ClubSidebar';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div>
        <NavMenu />
        <ClubSidebar />
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
