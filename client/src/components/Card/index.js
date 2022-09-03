import React from "react";
import Post from "./Post";

function Card({ id, type, title, time, content, like, likeAction, dislike, dislikeAction, tags }) {
  switch (type) {
    case "post":
      return (
        <Post
          id={id}
          title={title}
          time={time}
          content={content}
          like={like}
          likeAction={likeAction}
          dislike={dislike}
          dislikeAction={dislikeAction}
          tags={tags}
        />
      );
    default:
      return <div>Card</div>;
  }
}

export default Card;
