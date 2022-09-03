import React from "react";
import Post from "./Post";

function Card({ type, title, time, content, like, dislike }) {
  switch (type) {
    case "post":
      return (
        <Post
          title={title}
          time={time}
          content={content}
          like={like}
          dislike={dislike}
        />
      );
    default:
      return <div>Card</div>;
  }
}

export default Card;
