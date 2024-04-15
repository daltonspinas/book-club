import React, { createContext } from 'react';

export const AppContext = createContext({});

export const ClubsContext = createContext({
    clubsArray: [],
    setClubsArray: () => { }
})