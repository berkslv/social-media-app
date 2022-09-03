import React from "react";
import Logo from "images/logo-dark.svg";
import Home from "images/home.svg";
import User from "images/user.svg";
import Logout from "images/logout.svg";

function Header() {
  return (
    <header>
      <nav className="navbar navbar-dark bg-dark navbar-expand-lg d-none d-lg-block">
        <div className="container-fluid">
          <a className="navbar-brand" href="/">
            <img src={Logo} alt="logo" width="140px" />
          </a>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <a className="nav-link active" href="/">
                  Ana sayfa
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link active" href="/profile">
                  Profil
                </a>
              </li>
            </ul>
          </div>
          <div className="d-flex" role="search">
            <div className="btn-group" role="group" aria-label="Basic example">
              <a
                href="/login"
                className="btn btn-primary"
                type="submit"
              >
                Giriş yap
              </a>
              <a
                href="/register"
                className="btn btn-outline-primary"
                type="submit"
              >
                Üye ol
              </a>
            </div>
          </div>
        </div>
      </nav>
      <nav className="navbar navbar-dark bg-dark fixed-bottom navbar-expand-md d-lg-none d-block">
        <div className="container-fluid  d-flex justify-content-center">
          <button type="button" className="btn btn-dark" style={{ width: "33%" }}>
            <img src={Home} alt="logo" width="30px" />
          </button>
          <button type="button" className="btn btn-dark" style={{ width: "33%" }}>
            <img src={User} alt="logo" width="30px" />
          </button>
          <button type="button" className="btn btn-dark" style={{ width: "33%" }}>
            <img src={Logout} alt="logo" width="30px" />
          </button>
        </div>
      </nav>
    </header>
  );
}

export default Header;
