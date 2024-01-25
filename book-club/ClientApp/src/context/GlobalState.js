import React, { createContext } from 'react';

export const AppContext = createContext({
    pageTitle: "",
    setPageTitle: () => {},
    bookTitle: "",
    setBookTitle: () => {},
    bookAuthor: "",
    setBookAuthor: () => {},
    bookImage: "",
    setBookImage: () => {},
    meetingDate: "",
    setMeetingDate: () => {},
    meetingHost: "",
    setMeetingHost: () => {},
    meetingAddress: "",
    setMeetingAddress: () => {}
});

export const ClubsContext = createContext({
    clubsArray: [],
    setClubsArray: () => { }
})