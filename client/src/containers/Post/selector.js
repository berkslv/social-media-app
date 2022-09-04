import { createSelector } from "reselect";

export const selectPosts = (state) => state.posts;
export const selectPostId = (state, id) => id;

export const selectPostById = createSelector(
  [selectPosts, selectPostId],
  (posts, id) => {
    // eslint-disable-next-line eqeqeq
    return posts.data.find((post) => post.id == id);
  }
);

export const selectPostOrderByCreated = createSelector(
  [selectPosts],
  (posts) => {
    return posts.data.sort((a, b) => {
      return b.created - a.created;
    });
  }
);
