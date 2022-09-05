import Textarea from "components/Textarea";
import React from "react";

function CommentCreate({ onChangeContent, onSubmit  }) {
  return (
    <form className="card mt-3" onSubmit={onSubmit}>
      <div className="card-header">Yorum oluştur</div>
      <div className="card-body">
        <Textarea placeholder={"Neler düşünüyorsun?"} onChange={onChangeContent} />
        <input type="submit" className="btn btn-primary mt-2" />
      </div>
    </form>
  );
}

export default CommentCreate;
