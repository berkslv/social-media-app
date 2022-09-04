import { createSelector } from "reselect";

export const selectComments = (state) => state.comment;
export const selectCommentId = (state, id) => id;
export const selectCommentPostId = (state, postId) => postId;

export const selectCommentById = createSelector(
  [selectComments, selectCommentId],
  (comment, id) => {
    // eslint-disable-next-line eqeqeq
    return comment.data.find((comment) => comment.id == id);
  }
);

export const selectCommentByPostId = createSelector(
  [selectComments, selectCommentPostId],
  (comment, postId) => {
    if (comment.data.length > 0 && comment.data[0] !== undefined) {
      let selected = comment.data.filter((comment) => comment.postId === postId);
      
      return selected.sort((a, b) => {
        return b.created - a.created;
      });
    }
    return [];
  }
);
