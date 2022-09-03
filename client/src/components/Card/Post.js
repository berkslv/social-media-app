import React from "react";
import moment from "moment";
import "moment/locale/tr";
import Like from "images/like.svg";
import Dislike from "images/dislike.svg";
import Comment from "images/comment.svg";

function Post({ id, title, time, content, like, likeAction, dislike, dislikeAction, tags }) {
  const date = moment.unix(time).fromNow();
  const relativeLike = like - dislike;

  return (
    <div className="card my-3">
      <div className="card-body">
        <p className="card-title">
          {id} - @{title} · <span className="text-muted">{date}</span>
        </p>
        <p className="card-text">{content}</p>
        <button onClick={() => { likeAction(id) }} type="button" className="btn p-2">
          <img src={Like} alt="like" width="20" height="20" />
        </button>
        <button type="button" className="btn p-2">
          <span>{relativeLike}</span>
        </button>
        <button onClick={() => { dislikeAction(id) }} type="button" className="btn p-2">
          <img src={Dislike} alt="dislike" width="20" height="20" />
        </button>
        <button type="button" className="btn p-2 ms-4">
          <img src={Comment} alt="comment" width="20" height="20" />
        </button>
      </div>
      <div class="card-footer text-muted">
        {tags.map((tag) => (
          <span className="badge bg-primary me-1">{tag}</span>
        ))}
      </div>
    </div>
  );
}

export default Post;
