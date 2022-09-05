import React from "react";

function Button({ type, className, content, onClick }) {
  return (
    <button type={type} className={className} onClick={onClick}>
      {content}
    </button>
  );
}

export default Button;
