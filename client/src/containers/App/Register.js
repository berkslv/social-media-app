import React, { useState, useEffect } from "react";
import RegisterForm from "components/RegisterForm";
import { register } from "containers/App/actions";
import {
  getUniversities,
  getFaculties,
  getDepartments,
} from "containers/University/actions";
import { connect } from "react-redux";
import { useNavigate } from "react-router-dom";
import Loading from "components/Loading";

function Register({
  app,
  register,
  university,
  getUniversities,
  getFaculties,
  getDepartments,
}) {
  const [Email, setEmail] = useState("");
  const [Username, setUsername] = useState("");
  const [Name, setName] = useState("");
  const [Password, setPassword] = useState("");
  const [University, setUniversity] = useState(null);
  const [Faculty, setFaculty] = useState(null);
  const [Department, setDepartment] = useState(null);
  const navigate = useNavigate();

  const onChangeEmailHandler = (event) => {
    setEmail(event.currentTarget.value);
  };

  const onChangePasswordHandler = (event) => {
    setPassword(event.currentTarget.value);
  };

  const onChangeUsernameHandler = (event) => {
    setUsername(event.currentTarget.value);
  };

  const onChangeNameHandler = (event) => {
    setName(event.currentTarget.value);
  };

  const onChangeUniversityHandler = (event) => {
    setUniversity(event.value);
  };

  const onChangeFacultyHandler = (event) => {
    setFaculty(event.value);
  };

  const onChangeDepartmentHandler = (event) => {
    setDepartment(event.value);
  };

  const onSubmitHandler = (event) => {
    event.preventDefault();

    const model = {
      email: Email,
      username: Username,
      name: Name,
      password: Password,
      universityId: University,
      facultyId: Faculty,
      departmentId: Department,
    };

    register(model);
  };

  useEffect(() => {
    getUniversities();
  }, []);

  useEffect(() => {
    if (University) {
      getFaculties(University);
    }
  }, [University]);

  useEffect(() => {
    if (Faculty) {
      getDepartments(Faculty);
    }
  }, [Faculty]);

  return (
    <>
      {app.loading ? (
        <Loading fullscreen />
      ) : (
        <RegisterForm
          error={app.error}
          message={app.message}
          onChangeEmail={onChangeEmailHandler}
          onChangePassword={onChangePasswordHandler}
          onChangeName={onChangeNameHandler}
          onChangeUsername={onChangeUsernameHandler}
          onChangeUniversity={onChangeUniversityHandler}
          onChangeFaculty={onChangeFacultyHandler}
          onChangeDepartment={onChangeDepartmentHandler}
          onSubmit={onSubmitHandler}
          universities={university.universities}
          faculties={university.faculties}
          departments={university.departments}
        />
      )}
    </>
  );
}

const mapStateToProps = (state) => {
  return {
    app: state.app,
    university: state.university,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    register: (model) => dispatch(register(model)),
    getUniversities: () => dispatch(getUniversities()),
    getFaculties: (universityId) => dispatch(getFaculties(universityId)),
    getDepartments: (facultyId) => dispatch(getDepartments(facultyId)),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Register);
