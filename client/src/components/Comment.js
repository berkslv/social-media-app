import React from "react";

const Comment = ({ comment }) => {
  return (
    <article className="media">
      <figure className="media-left">
        <p className="image is-48x48">
          <img
            alt=""
            src="https://imebehavioralhealth.com/wp-content/uploads/2021/10/user-icon-placeholder-1.png"
          />
        </p>
      </figure>
      <div className="media-content">
        <div className="content">
          <p>
            <strong>John Smith</strong> <small>@{comment.authorId}</small>{" "}
            <small>31m</small>
            <br />
            {comment.content}
          </p>
        </div>
      </div>
    </article>
  );
};

export default Comment;
