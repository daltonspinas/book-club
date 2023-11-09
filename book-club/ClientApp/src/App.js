import React, { useState, useEffect } from 'react';
import { Route, Routes, useLocation } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';
import { AppContext } from './context/GlobalState';

export default function App() {
  const [pageTitle, setPageTitle] = useState();

  const appContextValue = {pageTitle, setPageTitle};

  const location = useLocation();

  useEffect(() => {
    const activeRoute = AppRoutes.find(x => x.path == location.pathname);
    activeRoute?.title ? setPageTitle(activeRoute.title) : setPageTitle("Placeholder Title")
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
