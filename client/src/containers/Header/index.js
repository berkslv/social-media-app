import React from "react";
import Logo from "images/logo-dark.svg";
import Home from "images/home.svg";
import User from "images/user.svg";
import Logout from "images/logout.svg";
import Login from "images/login.svg";
import { Link } from "react-router-dom";
import { useSelector } from "react-redux";

function Header() {
  const app = useSelector((state) => state.app);

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
              {app.user && (
                <li className="nav-item">
                  <Link to={`/user/${app.user.id}`} className="nav-link active">
                    {app.user.name}
                  </Link>
                </li>
              )}
            </ul>
          </div>
          <div className="d-flex" role="search">
            <div className="btn-group" role="group" aria-label="Basic example">
              {app.isAuthenticated ? (
                <>
                  <Link to={`/logout`} className="btn btn-outline-primary">
                    Çıkış yap
                  </Link>
                </>
              ) : (
                <>
                  <Link to={`/login`} className="btn btn-primary">
                    Giriş yap
                  </Link>
                  <Link to={`/login`} className="btn btn-outline-primary">
                    Üye ol
                  </Link>
                </>
              )}
            </div>
          </div>
        </div>
      </nav>
      <nav className="navbar navbar-dark bg-dark fixed-bottom navbar-expand-md d-lg-none d-block">
        <div className="container-fluid  d-flex justify-content-center">
          <Link to={`/feed`} className="btn btn-dark" style={{ width: "33%" }}>
            <img src={Home} alt="logo" width="30px" />
          </Link>
          {app.user && (
          <Link
            to={`/user/${app.user.id}`}
            className="btn btn-dark"
            style={{ width: "33%" }}
          >
            <img src={User} alt="logo" width="30px" />
          </Link>
          )}
          {app.isAuthenticated ? (
            <Link
              to={`/logout`}
              className="btn btn-dark"
              style={{ width: "33%" }}
            >
              <img src={Logout} alt="logo" width="30px" />
            </Link>
          ) : (
            <Link
              to={`/login`}
              className="btn btn-dark"
              style={{ width: "33%" }}
            >
              <img src={Login} alt="logo" width="30px" />
            </Link>
          )}
        </div>
      </nav>
    </header>
  );
}

export default Header;
