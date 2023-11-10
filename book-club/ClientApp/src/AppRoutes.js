import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    path: '/',
    element: <Home />,
    title: 'Home'
  },
  {
    path: '/counter',
    element: <Counter />,
    title: 'Counter Title'
  },
  {
    path: '/fetch-data',
    element: <FetchData />,
    title: 'Fetch Title'
  }
];

export default AppRoutes;
