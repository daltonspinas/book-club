import React, { useContext, useEffect, useState } from "react";
import { AppUserContext } from "../context/UserContext";

export function ClubSidebar() {

  const { appUser, setAppUser } = useContext(AppUserContext);

  useEffect(() => {
  }, [])

  return (
    <div id="clubSidebar" className="bg-green-700 h-screen w-sidebarWidth">
      <ul>
        {appUser?.bookClubs?.map(function (club, i) {
          return (
            <li
              key={i}
              onClick={function handleClick() {
                console.log(`${club.clubName}`);
              }}
            >
              {club.clubName}
            </li>
          );
        })}
      </ul>
    </div>
  );
}
