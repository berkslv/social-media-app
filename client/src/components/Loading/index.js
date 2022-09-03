import React from "react";

function Loading({ fullscreen }) {
  if (fullscreen) {
    return (
      <div className="position-absolute d-flex justify-content-center align-items-center bg-light top-0 start-0" style={{ height: "100vh", width: "100vw", zIndex: "40" }}>
      <div className="spinner-border" role="status">
      </div>
    </div>
    );
  } else {
    return (
      <div className="d-flex justify-content-center align-items-center">
        <div className="spinner-border" role="status">
        </div>
      </div>
    );
  }
}

export default Loading;
