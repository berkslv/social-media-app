import React from "react";
import Comment from "./Comment";
import Post from "./Post";

function Card({ type, comment, post, likeAction, dislikeAction }) {
  switch (type) {
    case "post":
      return (
        <Post
          post={post}
          likeAction={likeAction}
          dislikeAction={dislikeAction}
        />
      );
    case "comment":
      return <Comment comment={comment} />;
    default:
      return <div> Card </div>;
  }
}

export default Card;
