import React from "react";

function Textarea({ placeholder, onChange, rows = 3 }) {
  return (
    <div class="mb-3">
      <textarea
        class="form-control"
        id="exampleFormControlTextarea1"
        rows={rows}
        onChange={onChange}
        placeholder={placeholder}
      ></textarea>
    </div>
  );
}

export default Textarea;
