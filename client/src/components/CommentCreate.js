import { useState } from "react";
import { addComments } from "../utils/api.js";

const CommentCreate = ({ id }) => {
  const [Content, setContent] = useState([]);


  return (
    <article className="media">
      <figure className="media-left">
        <p className="image is-64x64">
          <img
            alt=""
            src="https://imebehavioralhealth.com/wp-content/uploads/2021/10/user-icon-placeholder-1.png"
          />
        </p>
      </figure>
      <div className="media-content">
        <div className="field">
          <p className="control">
            <textarea
              className="textarea"
              placeholder="Neler oluyor..."
              onChange={(e) => setContent(e.target.value)}
            ></textarea>
          </p>
        </div>
        <div className="field">
          <p className="control">
            <button className="button is-link" onClick={() => { addComments(id, Content) }} >Gönder</button>
          </p>
        </div>
      </div>
    </article>
  );
};

export default CommentCreate;
