import React, { useState } from "react";
import { connect } from "react-redux";
import { createPost } from "./actions";
import PostCreate from "components/PostCreate";

function Create({ createPost }) {
  const [Content, setContent] = useState("");
  // eslint-disable-next-line no-unused-vars
  const [TagId, setTagId] = useState([2, 3]);

  const handleSubmit = (e) => {
    e.preventDefault();
    const post = {
      Content,
      TagId,
    };
    createPost(post);
  };

  const handleChange = (e) => {
    setContent(e.target.value);
  };

  return (
    <PostCreate onChange={handleChange} onSubmit={handleSubmit}></PostCreate>
  );
}

const mapStateToProps = (state) => {
  return {
    posts: state.posts,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    createPost: (post) => dispatch(createPost(post)),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Create);
