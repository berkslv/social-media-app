import React from "react";

function Textarea({ placeholder, onChange, rows = 3 }) {
  return (
    <div className="mb-3">
      <textarea
        className="form-control"
        id="exampleFormControlTextarea1"
        rows={rows}
        onChange={onChange}
        placeholder={placeholder}
      ></textarea>
    </div>
  );
}

export default Textarea;
