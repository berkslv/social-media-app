import CommentCreate from "./CommentCreate";
import Comment from "./Comment";
import LikeIcon from "../assets/like.svg";
import DislikeIcon from "../assets/dislike.svg";
import CommentIcon from "../assets/comment.svg";
import DotsIcon from "../assets/dots-vertical.svg";
import { Link } from "react-router-dom";
import { likePost, dislikePost } from "../utils/api";

const Post = ({ post, comments, detail = false }) => {
  return (
    <>
      <article className="media">
        <figure className="media-left">
          <p className="image is-64x64">
            <img
              alt="/"
              src="https://imebehavioralhealth.com/wp-content/uploads/2021/10/user-icon-placeholder-1.png"
            />
          </p>
        </figure>
        <div className="media-content">
          <div className="content">
            <p>
              <strong>John Smith</strong> <small>@{post.authorId}</small>{" "}
              <small>31m</small>
              <br />
              {post?.content}
            </p>
          </div>
          <nav className="level is-mobile">
            <div className="level-left">
              <button
                className="button is-inverted is-success"
                onClick={() => {
                  likePost(post.id);
                }}
              >
                <span class="icon is-small">
                  <img alt="like" src={LikeIcon} />
                </span>
              </button>
              <span className="icon">{post?.like - post?.dislike}</span>
              <button
                className="button is-inverted is-success"
                onClick={() => {
                  dislikePost(post.id);
                }}
              >
                <span class="icon is-small">
                  <img alt="dislike" src={DislikeIcon} />
                </span>
              </button>
              <Link to={`/post-detail/${post.id}`} className="button is-inverted is-success">
                <span className="icon is-small">
                  <img alt="comment" src={CommentIcon} />
                </span>
              </Link>
            </div>
          </nav>

          {detail &&
            comments?.map((comment) => (
              <Comment key={comment.id} comment={comment} />
            ))}
        </div>
        <div className="media-right">
          <a href="/" className="icon is-small">
            <img alt="settings" src={DotsIcon} />
          </a>
        </div>
      </article>

      {detail && <CommentCreate id={post.id} />}
    </>
  );
};

export default Post;
