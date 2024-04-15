import React, {useContext} from 'react';
import { AppContext } from '../context/GlobalState';
import useGetBook from '../APIs/BooksAPI';

export function Home() {
    const { bookImage, bookTitle, bookAuthor, meetingDate, meetingHost, meetingAddress } = useContext(AppContext)

    //call books API, update context
    //temp ID for Dune used, replace with DB entry and context later
    const bookId = "OXzLsgEACAAJ?key=AIzaSyB8Qt63pYxZHRNxlDJQQUYQLS4Zuqcw5ZU"
    useGetBook(bookId)

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