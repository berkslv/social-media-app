import { selectPosts } from "containers/Post/selector";
import { createSelector } from "reselect";

export const selectUser = (state) => state.user;
export const selectUserId = (state, id) => id;

export const selectUserById = createSelector(
  [selectUser, selectUserId],
  (user, id) => {
    // eslint-disable-next-line eqeqeq
    return user.data.find((user) => user.id == id);
  }
);

export const selectUserPost = createSelector(
  [selectPosts, selectUser],
  (post, user) => {
    let selected = null;

    if (user.selectedUserId) {
      selected = post.data.filter(
        (post) => post.authorId.toString() === user.selectedUserId
      );
    } else {
      selected = post.data;
    }

    return selected.sort((a, b) => {
      return b.created - a.created;
    });
  }
);
