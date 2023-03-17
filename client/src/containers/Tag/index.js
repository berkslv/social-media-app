import React, { useEffect } from "react";
import { getTags, selectTag, deselectTag } from "./actions";
import { connect } from "react-redux";
import Button from "components/Button";

function Tag({ tag, getTags, selectTag, deselectTag }) {
  
  useEffect(() => {
    if (tag.data.length === 0) {
      getTags();
    }
  }, [getTags]);

  const selectTagHandler = (tagId) => {
    if (tag.selectedTagId === tagId) {
      deselectTag();
    } else {
      selectTag(tagId);
    }
  };

  return (
    <div className="d-flex justify-content-end">
      {tag.data &&
        tag.data.map((item) => (
          <Button
            key={item.id}
            className={`btn mx-1 ${tag.selectedTagId === item.id ? "btn-dark" : "btn-outline-dark"}`}
            type="button"
            content={item.name}
            onClick={() => selectTagHandler(item.id)}
          />
        ))}
    </div>
  );
}

const mapStateToProps = (state) => {
  return {
    tag: state.tag,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    getTags: () => dispatch(getTags()),
    selectTag: (tagId) => dispatch(selectTag(tagId)),
    deselectTag: () => dispatch(deselectTag()),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Tag);
