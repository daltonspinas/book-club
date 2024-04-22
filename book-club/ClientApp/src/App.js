import React, { useState, useEffect } from "react";
import { Route, Routes, useLocation } from "react-router-dom";
import AppRoutes from "./AppRoutes";
import { Layout } from "./components/Layout";
import "./custom.css";
import { AppContext } from "./context/GlobalContext";
import AxiosConfig from "./API/axiosConfig";
import { AppUserContext } from "./context/UserContext";
import { userAPI } from "./API/Controllers/User";
import { booksAPI } from "./API/Controllers/Books";

export default function App() {
  const [pageTitle, setPageTitle] = useState();
  const [bookImage, setBookImage] = useState(
    "https://prodimage.images-bn.com/lf?set=key%5Bresolve.pixelRatio%5D,value%5B1%5D&set=key%5Bresolve.width%5D,value%5B300%5D&set=key%5Bresolve.height%5D,value%5B10000%5D&set=key%5Bresolve.imageFit%5D,value%5Bcontainerwidth%5D&set=key%5Bresolve.allowImageUpscaling%5D,value%5B0%5D&set=key%5Bresolve.format%5D,value%5Bwebp%5D&source=url%5Bhttps://prodimage.images-bn.com/pimages/9780425266540_p0_v6_s600x595.jpg%5D&scale=options%5Blimit%5D,size%5B300x10000%5D&sink=format%5Bwebp%5D"
  );
  const [bookTitle, setBookTitle] = useState("Default Title");
  const [bookAuthor, setBookAuthor] = useState("Default Author");
  const [meetingDate, setMeetingDate] = useState(new Date().toString());
  const [meetingHost, setMeetingHost] = useState("Default Host");
  const [meetingAddress, setMeetingAddress] = useState(
    "1234 Default Address, TestCity 12345"
  );

  const [pageLoading, setPageLoading] = useState(false)

  const [appUser, setAppUser] = useState();

  const appUserContextValue = { appUser, setAppUser };

  const appContextValue = {
    pageTitle,
    setPageTitle,
    bookImage,
    setBookImage,
    bookTitle,
    setBookTitle,
    bookAuthor,
    setBookAuthor,
    meetingDate,
    setMeetingDate,
    meetingHost,
    setMeetingHost,
    meetingAddress,
    setMeetingAddress,
  };

  useEffect(() => {
    // Try to get userInfo if there's already an access token
    if (localStorage.getItem("accessToken")) {
      setPageLoading(true)
      userAPI.getAppUserInfo().then((data) => {
        setAppUser(data)
        setPageLoading(false)
      });
    }
  }, []);

  const location = useLocation();

  useEffect(() => {
    const activeRoute = AppRoutes.find((x) => x.path == location.pathname);
    activeRoute?.title
      ? setPageTitle(activeRoute.title)
      : setPageTitle("Placeholder Title");
    //these methods populate placeholder data for now, will replace with a call to the books API
  }, [location]);

  //hit books api to update global context
  //ToDo: replace placeholder with book id from DB
  useEffect(() => {
    const placeholderBook = "OXzLsgEACAAJ?key=AIzaSyB8Qt63pYxZHRNxlDJQQUYQLS4Zuqcw5ZU"
    setPageLoading(true)
    booksAPI.getBook(placeholderBook).then((data) => {
      //authors come back in an array, assume first is main
      setBookAuthor(data.volumeInfo.authors[0])
      setBookTitle(data.volumeInfo.title)
      setPageLoading(false)
    })
  })

  return (
    <AppContext.Provider value={appContextValue}>
      <AppUserContext.Provider value={appUserContextValue}>
        <AxiosConfig></AxiosConfig>
        <Layout>
          <Routes>
            {AppRoutes.map((route, index) => {
              const { element, ...rest } = route;
              return <Route key={index} {...rest} element={element} />;
            })}
          </Routes>
        </Layout>
      </AppUserContext.Provider>
    </AppContext.Provider>
  );
}
