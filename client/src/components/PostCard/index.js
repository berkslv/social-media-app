import React from "react";
import moment from "moment";
import "moment/locale/tr";
import Like from "images/like.svg";
import Dislike from "images/dislike.svg";
import Comment from "images/comment.svg";
import { Link } from "react-router-dom";
import roles from "utils/roles";

function PostCard({ user, post, likeAction, dislikeAction, deleteAction }) {
  const date = moment.unix(post.created).fromNow();
  const relativeLike = post.like - post.dislike;

  return (
    <div className="card my-3">
      <div className="card-body">
        <p className="card-title">
          <span className="d-flex justify-content-between">
            <span>
              <Link to={`/user/${post.authorId}`}>@{post.username}</Link> ·{" "}
              <span className="text-muted">{date}</span>
            </span>
            {user.id === post.authorId.toString() && (
              <span>
                <button
                  onClick={() => deleteAction(post.id)}
                  type="button"
                  className="btn-close"
                  aria-label="Close"
                ></button>
              </span>
            )}
          </span>
          <span className="text-muted">
            {post.authorUniversity === null ? (
              <span className="fw-bold font-monospace text-danger">Admin</span>
            ) : (
              <span>
                {post.authorUniversity} - {post.authorFaculty} -{" "}
                {post.authorDeparment}
              </span>
            )}
          </span>
        </p>
        <p className="card-text">{post.content}</p>
        <button
          onClick={() => {
            likeAction(post.id);
          }}
          type="button"
          className="btn p-2"
        >
          <img src={Like} alt="like" width="20" height="20" />
        </button>
        <button type="button" className="btn p-2">
          <span>{relativeLike}</span>
        </button>
        <button
          onClick={() => {
            dislikeAction(post.id);
          }}
          type="button"
          className="btn p-2"
        >
          <img src={Dislike} alt="dislike" width="20" height="20" />
        </button>
        <Link to={`/feed/${post.id}`} className="btn p-2 ms-4">
          <img src={Comment} alt="comment" width="20" height="20" />
        </Link>
      </div>
      {post.tags.length > 0 && (
        <div className="card-footer text-muted">
         {post.tags.map((tag) => (
            <span key={tag.id} className="badge bg-primary me-1">
              {tag}
            </span>
          ))}
        </div>
      )}
      </div>
  );
}

export default PostCard;
