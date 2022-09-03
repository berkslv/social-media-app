import React from "react";
import moment from "moment";
import "moment/locale/tr";
import Like from "images/like.svg";
import LikeSolid from "images/like-solid.svg";
import Dislike from "images/dislike.svg";
import DislikeSolid from "images/dislike-solid.svg";

function Comment({ comment, likeAction, dislikeAction, }) {
  const date = moment.unix(comment.created).fromNow();
  const relativeLike = comment.like - comment.dislike;

  return (
    <div className="card my-3">
      <div className="card-body">
        <p className="card-title">
          {comment.id} - @{comment.username} · <span className="text-muted">{date}</span>
        </p>
        <p className="card-text">{comment.content}</p>
        <button onClick={() => { likeAction(comment.id) }} type="button" className="btn p-2">
          {comment.liked ? <img src={LikeSolid} alt="like" width="20" height="20" /> : <img src={Like} alt="like" width="20" height="20" />}
        </button>
        <button type="button" className="btn p-2">
          <span>{relativeLike}</span>
        </button>
        <button onClick={() => { dislikeAction(comment.id) }} type="button" className="btn p-2">
          {comment.disliked ? <img src={DislikeSolid} alt="dislike" width="20" height="20" /> : <img src={Dislike} alt="dislike" width="20" height="20" />}
        </button>
      </div>
    </div>
  );
}

export default Comment;
