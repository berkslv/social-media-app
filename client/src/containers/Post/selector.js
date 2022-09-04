import { selectTags } from "containers/Tag/selector";
import { createSelector } from "reselect";

export const selectPosts = (state) => state.post;
export const selectPostId = (state, id) => id;

export const selectPostById = createSelector(
  [selectPosts, selectPostId],
  (post, id) => {
    // eslint-disable-next-line eqeqeq
    return post.data.find((post) => post.id == id);
  }
);

export const selectPost = createSelector(
  [selectPosts, selectTags],
  (post, tag) => {
    let selected = null;
    
    if (tag.selectedTagId) {
      selected =  post.data.filter((post) => post.tagId.includes(tag.selectedTagId));
    } else {
      selected = post.data;
    }

    return selected.sort((a, b) => {
      return b.created - a.created;
    });
  }
);
