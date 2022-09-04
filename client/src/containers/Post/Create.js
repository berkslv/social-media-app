import React, { useState } from "react";
import { connect } from "react-redux";
import { createPost } from "./actions";
import PostCreate from "components/PostCreate";
import Loading from "components/Loading";

function Create({ tag, createPost }) {
  const [Content, setContent] = useState("");
  // eslint-disable-next-line no-unused-vars
  const [TagId, setTagId] = useState([]);

  const handleSubmit = (e) => {
    e.preventDefault();
    const post = {
      Content,
      TagId,
    };
    createPost(post);
    setContent("");
    setTagId([]);
    e.target.reset();
  };

  const handleContentChange = (e) => {
    setContent(e.target.value);
  };

  const handleCheckboxChange = (e) => {
    const { checked, value } = e.target;
    if (checked) {
      setTagId([...TagId, parseInt(value)]);
    } else {
      setTagId(TagId.filter((tag) => tag !== parseInt(value)));
    }
  };

  return (
    <>
      {tag.loading ? (
        <Loading />
      ) : (
        <PostCreate
          onChangeContent={handleContentChange}
          onChangeCheckbox={handleCheckboxChange}
          tags={tag.data}
          onSubmit={handleSubmit}
        ></PostCreate>
      )}
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
    createPost: (post) => dispatch(createPost(post)),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Create);
