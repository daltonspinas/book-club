import React, { useContext, useState } from 'react';
import { getBookByID } from '../apis/BooksApi';

export function ClubSidebar({ clubsArray = [] }) {
    return (
        <div id="clubSidebar" className="bg-green-700 h-screen w-sidebarWidth">
            <ul>{
                clubsArray.map(function (club, i) {
                    return (
                        //todo: replace the below log with a context hook once multiple book club functionality is in place
                        <li key={i} onClick={
                            function handleClick() { console.log(`${club.name}`) }
                        }>{club.name}</li>
                    )
                })
            }
            </ul>
        </div>
    )
}