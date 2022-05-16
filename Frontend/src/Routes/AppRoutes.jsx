import { CircularProgress } from "@mui/material";
import { lazy, Suspense } from "react";
import { Route, HashRouter as Router, Routes } from "react-router-dom";
import { useStore } from "../Store/store";


const Home = lazy(() => import("../Pages/Homepage/Index"));
const Login = lazy(() => import("../Pages/Auth/Login"));
const Register = lazy(() => import("../Pages/Auth/Register"));
const Profile = lazy(() => import("../Pages/Profile/index"));
const LogedInHome = lazy(() => import("../Pages/LogedInPage/Homepage"));

const AppRoutes = () => {
  const login =  useStore(state=>state.logedIn)
  const routes = [
    {
      path: "/",
      element: Home,
    },
  ];

  return (
    <Router>
      <Suspense fallback={
          <div className="main-loader" >
               <CircularProgress size={130} style={{color:'#000000'}}  />
          </div>
      }>
        <Routes>
          
          <Route path="/homepage" element={<LogedInHome />} />
          <Route path="/profile" element={<Profile />} />

          <Route path="/register" element={<Register />} />
          <Route path="/login" element={<Login />} />
          <Route path="/" element={<Home />} />
        </Routes>
      </Suspense>
    </Router>
  );
};

export default AppRoutes;
