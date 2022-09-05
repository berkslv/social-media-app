import React, { useState, useEffect } from "react";
import VerifyForm from "components/VerifyForm";
import { verify, resetMessage } from "./actions";
import { connect } from "react-redux";

function Verify({ app, verify, resetMessage }) {
  const [Email, setEmail] = useState("");
  const [Code, setCode] = useState("");

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


  return (
    <VerifyForm
      isVerified={app.isVerified}
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
    resetMessage: () => dispatch(resetMessage()),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Verify);
