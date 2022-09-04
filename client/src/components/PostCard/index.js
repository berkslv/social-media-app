import React from "react";
import moment from "moment";
import "moment/locale/tr";
import Like from "images/like.svg";
import LikeSolid from "images/like-solid.svg";
import Dislike from "images/dislike.svg";
import DislikeSolid from "images/dislike-solid.svg";
import Comment from "images/comment.svg";
import { Link } from "react-router-dom";

function PostCard({ post, likeAction, dislikeAction, }) {
  const date = moment.unix(post.created).fromNow();
  const relativeLike = post.like - post.dislike;

  return (
    <div className="card my-3">
      <div className="card-body">
        <p className="card-title">
          @{post.username} · <span className="text-muted">{date}</span>
        </p>
        <p className="card-text">{post.content}</p>
        <button onClick={() => { likeAction(post.id) }} type="button" className="btn p-2">
          {post.liked ? <img src={LikeSolid} alt="like" width="20" height="20" /> : <img src={Like} alt="like" width="20" height="20" />}
        </button>
        <button type="button" className="btn p-2">
          <span>{relativeLike}</span>
        </button>
        <button onClick={() => { dislikeAction(post.id) }} type="button" className="btn p-2">
          {post.disliked ? <img src={DislikeSolid} alt="dislike" width="20" height="20" /> : <img src={Dislike} alt="dislike" width="20" height="20" />}
        </button>
        <Link to={`/feed/${post.id}`} className="btn p-2 ms-4">
          <img src={Comment} alt="comment" width="20" height="20" />
        </Link>
      </div>
      <div class="card-footer text-muted">
        {post.tags.map((tag) => (
          <span className="badge bg-primary me-1">{tag}</span>
        ))}
      </div>
    </div>
  );
}

export default PostCard;
