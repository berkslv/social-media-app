import { useState, useEffect } from "react";
import Navbar from "../components/Navbar";
import Post from "../components/Post";
import { getComments, getPost } from "../utils/api";
import { useParams } from "react-router-dom";

const PostDetail = () => {
  let { id } = useParams();

  const [SinglePost, setSinglePost] = useState({});
  const [Comments, setComments] = useState([]);

  useEffect(() => {
    getPost(id, setSinglePost);
    getComments(id, setComments);
  }, []);

  return (
    <div className="hero is-fullheight has-background-white-ter">
      <Navbar />
      <div className="container p-5 is-max-desktop has-background-white">
        <Post key={SinglePost.id} post={SinglePost} comments={Comments} detail />
      </div>
    </div>
  );
};

export default PostDetail;
