import Textarea from "components/Textarea";
import React from "react";

function CommentCreate({ onChangeContent, onSubmit  }) {
  return (
    <form class="card mt-3" onSubmit={onSubmit}>
      <div class="card-header">Yorum oluştur</div>
      <div className="card-body">
        <Textarea placeholder={"Neler düşünüyorsun?"} onChange={onChangeContent} />
        <input type="submit" className="btn btn-primary mt-2" />
      </div>
    </form>
  );
}

export default CommentCreate;
