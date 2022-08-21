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
        class="navbar has-background-link-light is-hidden-touch"
        role="navigation"
        aria-label="main navigation"
      >
        <div class="navbar-menu">
          <div class="navbar-start">
            <a class="navbar-item" href="/">
              <img alt="" src={Logo} width="112" height="28" />
            </a>
            <a href="/" class="navbar-item has-text-link">
              Ana Sayfa
            </a>

            <a href="/" class="navbar-item has-text-link">
              Profil
            </a>
          </div>

          <div class="navbar-end">
            <div class="navbar-item">
              <div class="buttons">
                <a href="/" class="button is-link">
                  <strong>Kayıt ol</strong>
                </a>
                <a href="/" class="button is-light">
                  Giriş yap
                </a>
              </div>
            </div>
          </div>
        </div>
      </nav>
      {/* Mobile Navbar */}
      <nav
        class="navbar is-fixed-bottom is-hidden-desktop"
        role="navigation"
        aria-label="main navigation"
      >
        <div class="navbar-menu is-flex has-background-link-light is-justify-content-space-evenly is-align-content-center">
          <a href="/" class="navbar-item column py-0 has-text-centered">
            <img src={HomeIcon} class="" alt="home" />
          </a>
          <a href="/" class="navbar-item column py-0 has-text-centered">
            <img src={UserIcon} class="" alt="user" />
          </a>
          <a href="/" class="navbar-item column py-0 has-text-centered">
            <img src={LogoutIcon} class="" alt="logout" />
          </a>
        </div>
      </nav>
    </>
  );
};

export default Navbar;
