import React from "react";
import Logo from "images/logo-light.svg";
import { Link } from "react-router-dom";

function VerifyForm({ message, isVerified, onSubmit, onChangeEmail, onChangeCode }) {
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
        {(message !== null && isVerified) ? (
          <>
            <div className="alert alert-success" role="alert">
              {message}
            </div>
            <Link className="btn btn-success my-2" to="/login">
              Giriş yap
            </Link>
          </>
        ) : (
          <>
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
              <label htmlFor="exampleInputCode1">Onay kodu</label>
              <input
                onChange={onChangeCode}
                type="text"
                className="form-control"
                placeholder="123456"
              />
            </div>
            <input
              type="submit"
              className="btn btn-primary my-2"
              value="Hesabını onayla"
            />
          </>
        )}
      </form>
    </div>
  );
}

export default VerifyForm;
