import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { ClubSidebar } from './ClubSidebar';

export class Layout extends Component {
    static displayName = Layout.name;


    render() {

        //todo:subscribe to the ClubsContext once functionality is in place (user logs in -> updates subscribed book clubs)
        const testClubArr = [{ name: "testClubOne" }, { name: "testClubTwo" }]

        const wrapper = {
            display: "flex"
        }

        return (
            <div>
                <NavMenu />
                <div style={wrapper}>
                    <ClubSidebar clubsArray={testClubArr} style={{ flex: "1 1 auto" }} />
                    <Container style={{ flex: "1 8 auto" }}>
                        {this.props.children}
                    </Container>
                    <ClubSidebar style={{ flex: "1 1 auto" }} />
                </div>
            </div>
        );
    }
}
