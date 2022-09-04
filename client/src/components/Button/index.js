import React from "react";

function Button({ type, className, content, onSubmit }) {
  return (
    <button type={type} class={className} onSubmit={onSubmit}>
      {content}
    </button>
  );
}

export default Button;
