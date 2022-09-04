import Textarea from "components/Textarea";
import React from "react";

function PostCreate({ onChangeContent, onChangeCheckbox, onSubmit, tags }) {
  return (
    <form class="card mt-3" onSubmit={onSubmit}>
      <div class="card-header">Gönderi oluştur</div>
      <div className="card-body">
        <Textarea placeholder={"Neler oluyor?"} onChange={onChangeContent} />
        <div>
          {tags.map((tag) => (
            <div class="form-check form-check-inline">
              <input
                class="form-check-input"
                type="checkbox"
                value={tag.id}
                onChange={onChangeCheckbox}
              />
              <label class="form-check-label">
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
