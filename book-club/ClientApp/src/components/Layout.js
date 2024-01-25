import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { ClubSidebar } from './ClubSidebar';

export class Layout extends Component {
    static displayName = Layout.name;


    render() {

        //todo:pull in data for clubs attatched to user and pass along to the ClubSidebar component
        const testClubArr = [{ name: "test" }, { name: "testtwo" }]

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
