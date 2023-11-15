import React, { useState, useEffect } from 'react';
import { Route, Routes, useLocation } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';
import { AppContext } from './context/GlobalState';

export default function App() {
  const [pageTitle, setPageTitle] = useState();
  const [bookImage, setBookImage] = useState();
  const [bookTitle, setBookTitle] = useState();
  const [bookAuthor, setBookAuthor] = useState();
  const [meetingDate, setMeetingDate] = useState()
  const [meetingHost, setMeetingHost] = useState()
  const [meetingAddress, setMeetingAddress] = useState()


  const appContextValue = 
  {
    pageTitle, setPageTitle, 
    bookImage, setBookImage,
    bookTitle, setBookTitle,
    bookAuthor, setBookAuthor,
    meetingDate, setMeetingDate,
    meetingHost, setMeetingHost,
    meetingAddress, setMeetingAddress
  };

  const location = useLocation();

  useEffect(() => {
    const activeRoute = AppRoutes.find(x => x.path == location.pathname);
    activeRoute?.title ? setPageTitle(activeRoute.title) : setPageTitle("Placeholder Title");
    //these methods populate placeholder data for now, will replace with a call to the books API
    setBookImage("https://prodimage.images-bn.com/lf?set=key%5Bresolve.pixelRatio%5D,value%5B1%5D&set=key%5Bresolve.width%5D,value%5B300%5D&set=key%5Bresolve.height%5D,value%5B10000%5D&set=key%5Bresolve.imageFit%5D,value%5Bcontainerwidth%5D&set=key%5Bresolve.allowImageUpscaling%5D,value%5B0%5D&set=key%5Bresolve.format%5D,value%5Bwebp%5D&source=url%5Bhttps://prodimage.images-bn.com/pimages/9780425266540_p0_v6_s600x595.jpg%5D&scale=options%5Blimit%5D,size%5B300x10000%5D&sink=format%5Bwebp%5D",
    setBookTitle("Default Title"),
    setBookAuthor("Default Author"),
    //TODO: modify this date parsing to be prettier
    setMeetingDate(new Date().toString()),
    setMeetingHost("Default Host"),
    setMeetingAddress("1234 Default Address, TestCity 12345")
    )
}, [location]);

    return (
      <AppContext.Provider value={appContextValue}>
      <Layout>
        <Routes>
          {AppRoutes.map((route, index) => {
            const { element, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
          })}
        </Routes>
      </Layout>
      </AppContext.Provider>
    );
}
