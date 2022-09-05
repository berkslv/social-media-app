import Textarea from "components/Textarea";
import React from "react";

function PostCreate({ onChangeContent, onChangeCheckbox, onSubmit, tags }) {
  return (
    <form className="card mt-3" onSubmit={onSubmit}>
      <div className="card-header">Gönderi oluştur</div>
      <div className="card-body">
        <Textarea placeholder={"Neler oluyor?"} onChange={onChangeContent} />
        <div>
          {tags.map((tag) => (
            <div key={tag.id} className="form-check form-check-inline">
              <input
                className="form-check-input"
                type="checkbox"
                value={tag.id}
                onChange={onChangeCheckbox}
              />
              <label className="form-check-label">
                {tag.name}
              </label>
            </div>
          ))}
        </div>
        <input type="submit" className="btn btn-primary mt-2" />
      </div>
    </form>
  );
}

export default PostCreate;
