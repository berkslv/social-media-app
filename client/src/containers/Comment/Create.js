import React, { useState } from "react";
import { connect } from "react-redux";
import { createComment } from "./actions";
import CommentCreate from "components/CommentCreate";

function Create({ postId, createComment }) {
  const [Content, setContent] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    const post = {
      Content,
      postId,
    };
    createComment(post);
    setContent("");
    e.target.reset();
  };

  const handleContentChange = (e) => {
    setContent(e.target.value);
  };

  return (
    <>
      <CommentCreate
        onChangeContent={handleContentChange}
        onSubmit={handleSubmit}
      />
    </>
  );
}

const mapStateToProps = (state) => {
  return {
    tag: state.tag,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    createComment: (post) => dispatch(createComment(post)),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Create);
