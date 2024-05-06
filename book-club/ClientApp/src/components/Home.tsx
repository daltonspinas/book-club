import { useContext } from "react";
import { AppContext } from "../context/GlobalContext";
import { AppUserContext } from "../context/UserContext";
import { SearchBar } from "./SearchBar";

export function Home() {
  const {
    bookImage,
    bookTitle,
    setBookTitle,
    bookAuthor,
    meetingDate,
    meetingHost,
    meetingAddress,
  } = useContext(AppContext);

  const { appUser } = useContext(AppUserContext);

  const dummyListOptions = [
    "Dune",
    "Fifty Shades of Grey",
    "Harry Potter",
    "Angels and Demons",
  ];
  
  const getSearchInputVal = (event: any) => {
    console.log("input changed: ", event.currentTarget.value);
  };

  const getSearchInputSelection = (event: number) => {
    console.log("search selected: ", dummyListOptions[event]);
  };

  return (
    <div className="bg-indigo-500 w-mainWidth h-screen grid items-center justify-center max-h-screen gap-2">
      <h2>Welcome {appUser?.userName ? appUser.userName : "NOT LOGGED IN"}</h2>
      <SearchBar
        handleInputChange={getSearchInputVal}
        handleOptionSelect={getSearchInputSelection}
        ListOptions={dummyListOptions}
        placeHolder="book options"
      ></SearchBar>
      <img className="justify-self-center" src={bookImage}></img>
      <h1 className="justify-self-center text-4xl">{bookTitle}</h1>
      <h2 className="justify-self-center text-3xl">{bookAuthor}</h2>
      <h3 className="justify-self-center text-xl">
        Next Meeting: {meetingDate.toString()}
      </h3>
      <h3 className="justify-self-center text-xl">Host: {meetingHost}</h3>
      <h3 className="justify-self-center text-xl pb-20">
        Location: {meetingAddress}
      </h3>
    </div>
  );
}
