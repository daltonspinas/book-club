import React, {useContext, useState, useEffect} from 'react';
import { AppContext } from '../context/GlobalState';
import axios from "axios";

export function Home() {
    const { bookImage, bookTitle, setBookTitle, bookAuthor, setBookAuthor, meetingDate, meetingHost, meetingAddress } = useContext(AppContext)

    //Books API
    const client = axios.create({
        baseURL: "https://www.googleapis.com/books/v1/volumes/"
    })

    const practiceID = "OXzLsgEACAAJ?key=AIzaSyB8Qt63pYxZHRNxlDJQQUYQLS4Zuqcw5ZU"

    React.useEffect(() => {
        client.get(practiceID).then((response) => {
            let resultObj = {
                title: response.data.volumeInfo.title,
                //authors comes back as an array, may want to modify this later to handle multiple authors. For now assume first result is main/only author
                author: response.data.volumeInfo.authors[0],
            }
            setBookTitle(resultObj.title);
            setBookAuthor(resultObj.author);
        })
    }, []);

    return (
        <div className='bg-indigo-500 w-mainWidth h-screen grid items-center justify-center max-h-screen gap-2'>
      <img className='justify-self-center' src={bookImage} alt="bookImage"></img>
      <h1 className='justify-self-center text-4xl'>{bookTitle}</h1>
      <h2 className='justify-self-center text-3xl'>{bookAuthor}</h2>
      <h3 className='justify-self-center text-xl'>Next Meeting: {meetingDate}</h3>
      <h3 className='justify-self-center text-xl'>Host: {meetingHost}</h3>
      <h3 className='justify-self-center text-xl pb-20'>Location: {meetingAddress}</h3>
    </div>
  )
}