import React, { useState, useEffect } from "react";
import LoginForm from "components/LoginForm";
import { login } from "./actions";
import { connect } from "react-redux";
import { useNavigate } from "react-router-dom";

function Login({ app, login }) {
  const [Email, setEmail] = useState("");
  const [Password, setPassword] = useState("");
  const navigate = useNavigate();

  const onChangeEmailHandler = (event) => {
    setEmail(event.currentTarget.value);
  };

  const onChangePasswordHandler = (event) => {
    setPassword(event.currentTarget.value);
  };

  const onSubmitHandler = (event) => {
    event.preventDefault();
    login(Email, Password);
  };

  useEffect(() => {
    if (app.isAuthenticated) {
      navigate("/");
    }
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [app.loading]);
  

  return (
    <LoginForm
      error={app.error}
      onChangeEmail={onChangeEmailHandler}
      onChangePassword={onChangePasswordHandler}
      onSubmit={onSubmitHandler}
    />
  );
}

const mapStateToProps = (state) => {
  return {
    app: state.app,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    login: (email, password) => dispatch(login(email, password)),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Login);
