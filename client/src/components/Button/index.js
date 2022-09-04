import React from "react";

function Button({ type, className, content, onClick }) {
  return (
    <button type={type} class={className} onClick={onClick}>
      {content}
    </button>
  );
}

export default Button;
