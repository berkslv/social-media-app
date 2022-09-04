import Textarea from "components/Textarea";
import React from "react";

function PostCreate({ onChange, onSubmit }) {
  return (
    <form class="card" onSubmit={onSubmit}>
      <div class="card-header">Gönderi oluştur</div>
      <div className="card-body">
        <Textarea placeholder={"Neler oluyor?"} onChange={onChange} />
        <input type="submit" className="btn btn-primary" />
      </div>
    </form>
  );
}

export default PostCreate;
