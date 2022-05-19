import React from "react";
import { Link } from "react-router-dom";
import { useStore } from "../../Store/store";

function Navbar() {
  const LogedInUser = useStore((state) => state.logedIn);
  console.log(LogedInUser);
  const AppRoutes = [
    {
      title: "Home",
      to: "/",
    },
    {
      title: "Features",
      to: "/",
    },
    {
      title: "Register",
      to: "/register",
    },
    {
      title: "Login",
      to: "/login",
    },
  ];

  const LogedInroutes = [
    {
      title: "Home",
      to: "/homepage",
    },
    {
      title: "Features",
      to: "/",
    },
    {
      title: "Manage Profile",
      to: "/profile",
    },
    {
      title: "Logout",
      to: "",
    },
  ];

  return (
    <div className="primary-navbar-wrapper">
      <nav className="main-nav">
        <div className="logo">
          <p className="f-40 color-basalt-grey ">Logo</p>
        </div>
        <div className="nav-links ml-28 f-30">
          {LogedInUser
            ? LogedInroutes.map((route, index) => (
                <Link to={route.to} key={index}>
                  {route.title}{" "}
                </Link>
              ))
            : AppRoutes.map((route, index) => (
                <Link to={route.to} key={index}>
                  {route.title}{" "}
                </Link>
              ))}
        </div>
      </nav>
    </div>
  );
}

export default Navbar;
