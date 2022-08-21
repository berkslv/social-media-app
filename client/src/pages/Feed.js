import { useState, useEffect } from "react";
import Navbar from "../components/Navbar";
import Post from "../components/Post";
import { getPosts } from "../utils/api";


const Feed = () => {
  const [Posts, setPosts] = useState([]);

  useEffect(() => {
    getPosts(setPosts);
  }, []);

  return (
    <div className="hero is-fullheight has-background-white-ter">
      <Navbar />
      <div className="container p-5 is-max-desktop has-background-white">
        {Posts.map((post) => (
          <Post key={post.id} post={post} />
        ))}
      </div>
    </div>
  );
};

export default Feed;
