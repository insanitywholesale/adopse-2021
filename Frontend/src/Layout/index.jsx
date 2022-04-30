import React from "react";
import Footer from "../Component/Layout/Footer";
import Navbar from "../Component/Layout/Navbar";

function Layout({ background, children }) {
  return (
    <div className={`evalutaion-main-wrapper ${background}`}>
      <Navbar />
      <main className="primary-content-wrapper">{children}</main>
      <Footer />
    </div>
  );
}

export default Layout;
