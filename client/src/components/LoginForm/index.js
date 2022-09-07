import React from "react";
import Logo from "images/logo-light.svg";
import { Link } from "react-router-dom";

function LoginForm({ error, onSubmit, onChangeEmail, onChangePassword, visitorEvent }) {

  return (
    <div
      className="d-flex justify-content-center align-items-center bg-light"
      style={{ height: "100vh" }}
    >
      <form
        className="card p-4"
        style={{ minWidth: "320px" }}
        onSubmit={onSubmit}
      >
        <div className="mx-auto my-3">
          <img src={Logo} alt="logo" width="180px" />
        </div>
        <div className="form-group my-2">
          <label htmlFor="exampleInputEmail1">Email</label>
          <input
            onChange={onChangeEmail}
            type="email"
            className="form-control"
            placeholder="berkslv@gmail.com"
          />
        </div>
        <div className="form-group my-2">
          <label htmlFor="exampleInputPassword1">Parola</label>
          <input
            onChange={onChangePassword}
            type="password"
            className="form-control"
            placeholder="********"
          />
        </div>
        {error && (
          <div className="alert alert-danger" role="alert">
            {error}
          </div>
        )}
        <input
          type="submit"
          className="btn btn-primary my-2"
          value="Giriş Yap"
        />
        <button className="btn btn-primary my-2" onClick={visitorEvent}>
          Ziyaterçi olarak giriş yap
        </button>
        <Link className="btn btn-outline-primary my-2" to="/register">
          Üye ol
        </Link>
      </form>
    </div>
  );
}

export default LoginForm;
