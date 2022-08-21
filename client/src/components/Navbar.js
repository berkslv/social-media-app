import React from "react";
import Logo from "../assets/logo-light.svg";
import HomeIcon from "../assets/home.svg";
import UserIcon from "../assets/user.svg";
import LogoutIcon from "../assets/logout.svg";

const Navbar = () => {
  return (
    <>
      {/* Desktop Navbar */}
      <nav
        className="navbar has-background-link-light is-hidden-touch"
        role="navigation"
        aria-label="main navigation"
      >
        <div className="navbar-menu">
          <div className="navbar-start">
            <a className="navbar-item" href="/">
              <img alt="" src={Logo} width="112" height="28" />
            </a>
            <a href="/" className="navbar-item has-text-link">
              Ana Sayfa
            </a>

            <a href="/" className="navbar-item has-text-link">
              Profil
            </a>
          </div>

          <div className="navbar-end">
            <div className="navbar-item">
              <div className="buttons">
                <a href="/" className="button is-link">
                  <strong>Kayıt ol</strong>
                </a>
                <a href="/" className="button is-light">
                  Giriş yap
                </a>
              </div>
            </div>
          </div>
        </div>
      </nav>
      {/* Mobile Navbar */}
      <nav
        className="navbar is-fixed-bottom is-hidden-desktop"
        role="navigation"
        aria-label="main navigation"
      >
        <div className="navbar-menu is-flex has-background-link-light is-justify-content-space-evenly is-align-content-center">
          <a href="/" className="navbar-item column py-0 has-text-centered">
            <img src={HomeIcon} className="" alt="home" />
          </a>
          <a href="/" className="navbar-item column py-0 has-text-centered">
            <img src={UserIcon} className="" alt="user" />
          </a>
          <a href="/" className="navbar-item column py-0 has-text-centered">
            <img src={LogoutIcon} className="" alt="logout" />
          </a>
        </div>
      </nav>
    </>
  );
};

export default Navbar;
