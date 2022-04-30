import React from "react";
import { Link } from "react-router-dom";

function Footer() {
  return (
    <div className="primary-footer-wrapper ">
      <footer className="footer-main d-flex justify-content-center">
        {[1, 2, 3].map((items) => (
          <div className="nav-links-section" key={items}>
            <h4 className="f-35 mt-128">Footer Section</h4>
            <div className="f-25 d-flex flex-column">
              <Link to="/">Link</Link>
              <Link to="/">Link</Link>
              <Link to="/">Link</Link>
              <Link to="/">Link</Link>
            </div>
          </div>
        ))}
      </footer>
    </div>
  );
}

export default Footer;
