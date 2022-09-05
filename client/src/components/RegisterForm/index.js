import React, { useEffect, useState } from "react";
import Logo from "images/logo-light.svg";
import { Link } from "react-router-dom";
import Select from "react-select";

function Register({
  error,
  message,
  onSubmit,
  onChangeEmail,
  onChangePassword,
  onChangeUsername,
  onChangeName,
  onChangeUniversity,
  onChangeFaculty,
  onChangeDepartment,
  universities,
  faculties,
  departments,
}) {
  const universitiesToOptions = (universities) => {
    return universities.map((university) => {
      return {
        value: university.id,
        label: university.name,
      };
    });
  };

  const facultiesToOptions = (faculties) => {
    return faculties.map((faculty) => {
      return {
        value: faculty.id,
        label: faculty.name,
      };
    });
  };

  const departmentsToOptions = (departments) => {
    return departments.map((department) => {
      return {
        value: department.id,
        label: department.name,
      };
    });
  };

  const [universityOpt, setUniversityOpt] = useState([]);
  const [facultyOpt, setFacultyOpt] = useState([]);
  const [departmentOpt, setDepartmentOpt] = useState([]);

  useEffect(() => {
    setUniversityOpt(universitiesToOptions(universities));
  }, [universities]);

  useEffect(() => {
    setFacultyOpt(facultiesToOptions(faculties));
  }, [faculties]);

  useEffect(() => {
    setDepartmentOpt(departmentsToOptions(departments));
  }, [departments]);

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
          <label>İsim</label>
          <input
            onChange={onChangeName}
            type="name"
            className="form-control"
            placeholder="berk selvi"
          />
        </div>
        <div className="form-group my-2">
          <label>Email</label>
          <input
            onChange={onChangeEmail}
            type="email"
            className="form-control"
            placeholder="berkslv@gmail.com"
          />
        </div>
        <div className="form-group my-2">
          <label>Kullanıcı adı</label>
          <input
            onChange={onChangeUsername}
            type="name"
            className="form-control"
            placeholder="berkslv"
          />
        </div>
        <div className="form-group my-2">
          <label>Parola</label>
          <input
            onChange={onChangePassword}
            type="password"
            className="form-control"
            placeholder="********"
          />
        </div>
        <div className="form-group my-2">
          <label>Universite</label>
          <Select options={universityOpt} onChange={onChangeUniversity} />
        </div>
        <div className="form-group my-2">
          <label>Fakülte</label>
          <Select options={facultyOpt} onChange={onChangeFaculty} />
        </div>
        <div className="form-group my-2">
          <label>Bölüm</label>
          <Select options={departmentOpt} onChange={onChangeDepartment} />
        </div>
        {error && (
          <div className="alert alert-danger" role="alert">
            {error}
          </div>
        )}
        {message && (
          <>
            <div className="alert alert-success" role="alert">
              {message}
            </div>
            <Link className="btn btn-success my-2" to="/verify">
              Hesabını onayla
            </Link>
          </>
        )}
        <input type="submit" className="btn btn-primary my-2" value="Üye ol" />
        <Link className="btn btn-outline-primary my-2" to="/login">
          Giriş yap
        </Link>
      </form>
    </div>
  );
}

export default Register;
