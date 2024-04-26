import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { LoginSignup } from "./components/LoginSignup";

const AppRoutes = [
  {
    index: true,
    path: '/',
    element: < Home />,
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
  },
  {
    path: '/login-signup',
    element: <LoginSignup />,
    title: 'Login/Sign Up'
  }
];

export default AppRoutes;
