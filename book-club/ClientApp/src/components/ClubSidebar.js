import React, {useContext, useState} from 'react';

export function ClubSidebar({ clubsArray = [] }) {
    return(
        <div id="clubSidebar" className="bg-green-700 h-screen w-sidebarWidth">
            <ul>{ 
                clubsArray.map(function (club, i) {
                    return (
                        <li key={i}>{club.name}</li>
                    )
                })
            }
        </ul>
        </div>
    )
}