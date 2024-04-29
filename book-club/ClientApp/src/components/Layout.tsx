import React, { Component } from "react";
import { Container } from "reactstrap";
import { NavMenu } from "./NavMenu";
import { ClubSidebar } from "./ClubSidebar";

export default function Layout(props: any) {
  const wrapper = {
    display: "flex",
  };

  return (
    <div >
      <NavMenu />
      <div style={wrapper}>
        <ClubSidebar/>
        <Container style={{ flex: "1 8 auto" }}>
          {props.children}
        </Container>
      </div>
    </div>
  );
}
