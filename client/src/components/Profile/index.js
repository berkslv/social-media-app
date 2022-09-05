import React from 'react'
import roles from "utils/roles";

function Profile({ user }) {
  return (
    <div className="card">
    <div className="card-body">
      <h5 className="card-title">{user.name}</h5>
      <p className="card-text">
        {user.role === roles.ADMIN ? (
          <span className="fw-bold font-monospace text-danger">
            Admin
          </span>
        ) : (
          <p>
            <p className="text-muted">{user.role}</p>
            <p>
              <span className="text-muted">Üniversite:</span>{" "}
              <span className="fw-bold">{user.university}</span>
            </p>
            <p>
              <span className="text-muted">Fakülte:</span>{" "}
              <span className="fw-bold">{user.faculty}</span>
            </p>
            <p>
              <span className="text-muted">Bölüm:</span>{" "}
              <span className="fw-bold">{user.department}</span>
            </p>
          </p>
        )}
      </p>
    </div>
  </div>
  )
}

export default Profile