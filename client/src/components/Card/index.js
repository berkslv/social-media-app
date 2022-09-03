import React from "react";
import Post from "./Post";

function Card({ type, post, likeAction, dislikeAction, }) {
  switch (type) {
    case "post":
      return (
        <Post
          post={post}
          likeAction={likeAction}
          dislikeAction={dislikeAction}
        />
      );
    default:
      return <div>Card</div>;
  }
}

export default Card;
