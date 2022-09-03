import axios from "utils/axios";
import {
  GET_POST_REQUEST,
  GET_POST_FAILED,
  GET_POST_SUCCESS,

  GET_POSTS_REQUEST,
  GET_POSTS_FAILED,
  GET_POSTS_SUCCESS,

  LIKE_POST_REQUEST,
  LIKE_POST_FAILED,
  LIKE_POST_SUCCESS,

  DISLIKE_POST_REQUEST,
  DISLIKE_POST_FAILED,
  DISLIKE_POST_SUCCESS
} from "./types";

// ------------------------------------ GET POST ------------------------------------
export const getPostRequest = () => ({
  type: GET_POST_REQUEST,
});

export const getPostSuccess = (post) => ({
  type: GET_POST_SUCCESS,
  payload: post,
});

export const getPostFailed = (error) => ({
  type: GET_POST_FAILED,
  payload: error,
});

export const getPost = (id) => async (dispatch) => {
  dispatch(getPostRequest());
  try {
    const { data } = await axios.get(`/posts/${id}`);
    dispatch(getPostSuccess(data));
  } catch (error) {
    dispatch(getPostFailed(error));
  }
};

// ------------------------------------ GET POSTS ------------------------------------
export const getPostsRequest = () => ({
  type: GET_POSTS_REQUEST,
});

export const getPostsSuccess = (posts) => ({
  type: GET_POSTS_SUCCESS,
  payload: posts,
});

export const getPostsFailed = (error) => ({
  type: GET_POSTS_FAILED,
  payload: error,
});

export const getPosts = () => async (dispatch, getState) => {
  dispatch(getPostsRequest());
  try {
    const currentPage = getState().posts.currentPage;

    const { data } = await axios.get(
      `/posts?pageNumber=${currentPage + 1}&orderBy=Created_desc`
    );
    dispatch(getPostsSuccess(data));
  } catch (error) {
    dispatch(getPostsFailed(error));
  }
};


// ------------------------------------ LIKE POST ------------------------------------
export const likePostRequest = () => ({
  type: LIKE_POST_REQUEST,
});

export const likePostSuccess = (post) => ({
  type: LIKE_POST_SUCCESS,
  payload: post,
});

export const likePostFailed = (error) => ({
  type: LIKE_POST_FAILED,
  payload: error,
});

export const likePost = (id) => async (dispatch) => {
  dispatch(likePostRequest());
  try {
    const { data } = await axios.put(`/posts/${id}/like`);
    dispatch(likePostSuccess(data));
  } catch (error) {
    dispatch(likePostFailed(error));
  }
}

// ------------------------------------ DISLIKE POST ------------------------------------

export const dislikePostRequest = () => ({
  type: DISLIKE_POST_REQUEST,
});

export const dislikePostSuccess = (post) => ({
  type: DISLIKE_POST_SUCCESS,
  payload: post,
});

export const dislikePostFailed = (error) => ({
  type: DISLIKE_POST_FAILED,
  payload: error,
});

export const dislikePost = (id) => async (dispatch) => {
  dispatch(dislikePostRequest());
  try {
    const { data } = await axios.put(`/posts/${id}/dislike`);
    dispatch(dislikePostSuccess(data));
  } catch (error) {
    dispatch(dislikePostFailed(error));
  }
}
