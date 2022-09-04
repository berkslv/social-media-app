import React from "react";
import Logo from "images/logo-dark.svg";
import Home from "images/home.svg";
import User from "images/user.svg";
import Logout from "images/logout.svg";
import { Link } from "react-router-dom";

function Header() {
  return (
    <header>
      <nav className="navbar navbar-dark bg-dark navbar-expand-lg d-none d-lg-block">
        <div className="container-fluid">
          <Link to={`/feed`} className="navbar-brand">
            <img src={Logo} alt="logo" width="140px" />
          </Link>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <Link to={`/feed`} className="nav-link active">
                  Ana sayfa
                </Link>
              </li>
              <li className="nav-item">
                <Link to={`/profile`} className="nav-link active">
                  Profil
                </Link>
              </li>
            </ul>
          </div>
          <div className="d-flex" role="search">
            <div className="btn-group" role="group" aria-label="Basic example">
              <Link to={`/login`} className="btn btn-primary">
                Giriş yap
              </Link>
              <Link to={`/login`} className="btn btn-outline-primary">
                Üye ol
              </Link>
            </div>
          </div>
        </div>
      </nav>
      <nav className="navbar navbar-dark bg-dark fixed-bottom navbar-expand-md d-lg-none d-block">
        <div className="container-fluid  d-flex justify-content-center">
          <Link to={`/feed`} className="btn btn-dark" style={{ width: "33%" }}>
            <img src={Home} alt="logo" width="30px" />
          </Link>
          <Link to={`/profile`} className="btn btn-dark" style={{ width: "33%" }}>
            <img src={User} alt="logo" width="30px" />
          </Link>
          <Link to={`/login`} className="btn btn-dark" style={{ width: "33%" }}>
            <img src={Logout} alt="logo" width="30px" />
          </Link>
        </div>
      </nav>
    </header>
  );
}

export default Header;
