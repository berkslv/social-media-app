import React, { useState, useEffect } from "react";
import VerifyForm from "components/VerifyForm";
import { verify } from "./actions";
import { connect } from "react-redux";
import { useNavigate } from "react-router-dom";

function Verify({ app, verify }) {
  const [Email, setEmail] = useState("");
  const [Code, setCode] = useState("");
  const navigate = useNavigate();

  const onChangeEmailHandler = (event) => {
    setEmail(event.currentTarget.value);
  };

  const onChangeCodeHandler = (event) => {
    setCode(event.currentTarget.value);
  };

  const onSubmitHandler = (event) => {
    event.preventDefault();
    verify(Email, Code);
  };

  useEffect(() => {
    if (app.isAuthenticated) {
      navigate("/");
    }
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [app.loading]);
  

  return (
    <VerifyForm
      message={app.message}
      onChangeEmail={onChangeEmailHandler}
      onChangeCode={onChangeCodeHandler}
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
    verify: (email, code) => dispatch(verify(email, code)),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Verify);
