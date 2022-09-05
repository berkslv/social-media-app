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
  DISLIKE_POST_SUCCESS,
  CREATE_POST_REQUEST,
  CREATE_POST_FAILED,
  CREATE_POST_SUCCESS,
  DELETE_POST_REQUEST,
  DELETE_POST_FAILED,
  DELETE_POST_SUCCESS,
} from "./types";

// ------------------------------------ GET POST ------------------------------------
const getPostRequest = () => ({
  type: GET_POST_REQUEST,
});

const getPostSuccess = (post) => ({
  type: GET_POST_SUCCESS,
  payload: post,
});

const getPostFailed = (error) => ({
  type: GET_POST_FAILED,
  payload: error,
});

export const getPost = (id) => async (dispatch) => {
  dispatch(getPostRequest());
  try {
    const { data, status } = await axios.get(`/posts/${id}`);

    if (status === 204) dispatch(getPostFailed("No post found"));
    if (status === 200) {
      if (data.success) dispatch(getPostSuccess(data));
      else dispatch(getPostFailed(data.message));
    }
  } catch (error) {
    dispatch(getPostFailed(error));
  }
};

// ------------------------------------ GET POSTS ------------------------------------
const getPostsRequest = () => ({
  type: GET_POSTS_REQUEST,
});

const getPostsSuccess = (posts) => ({
  type: GET_POSTS_SUCCESS,
  payload: posts,
});

const getPostsFailed = (error) => ({
  type: GET_POSTS_FAILED,
  payload: error,
});

export const getPosts = () => async (dispatch, getState) => {
  dispatch(getPostsRequest());
  try {
    const currentPage = getState().post.currentPage;

    const { data, status } = await axios.get(
      `/posts?pageNumber=${currentPage + 1}&orderBy=Created_desc`
    );
    if (status === 204) dispatch(getPostsFailed("No posts found"));
    if (status === 200) {
      if (data.success) dispatch(getPostsSuccess(data));
      else dispatch(getPostsFailed(data.message));
    }
  } catch (error) {
    dispatch(getPostsFailed(error));
  }
};

// ------------------------------------ LIKE POST ------------------------------------
const likePostRequest = () => ({
  type: LIKE_POST_REQUEST,
});

const likePostSuccess = (post) => ({
  type: LIKE_POST_SUCCESS,
  payload: post,
});

const likePostFailed = (error) => ({
  type: LIKE_POST_FAILED,
  payload: error,
});

export const likePost = (id) => async (dispatch) => {
  dispatch(likePostRequest());
  try {
    const { data, status } = await axios.put(`/posts/${id}/like`);

    if (status === 204) dispatch(likePostFailed("No post found"));
    if (status === 200) {
      if (data.success) dispatch(likePostSuccess(data));
      else dispatch(likePostFailed(data.message));
    }
  } catch (error) {
    dispatch(likePostFailed(error));
  }
};

// ------------------------------------ DISLIKE POST ------------------------------------

const dislikePostRequest = () => ({
  type: DISLIKE_POST_REQUEST,
});

const dislikePostSuccess = (post) => ({
  type: DISLIKE_POST_SUCCESS,
  payload: post,
});

const dislikePostFailed = (error) => ({
  type: DISLIKE_POST_FAILED,
  payload: error,
});

export const dislikePost = (id) => async (dispatch) => {
  dispatch(dislikePostRequest());
  try {
    const { data, status } = await axios.put(`/posts/${id}/dislike`);

    if (status === 204) dispatch(dislikePostFailed("No post found"));
    if (status === 200) {
      if (data.success) dispatch(dislikePostSuccess(data));
      else dispatch(dislikePostFailed(data.message));
    }
  } catch (error) {
    dispatch(dislikePostFailed(error));
  }
};

// ------------------------------------ CREATE POST ------------------------------------

const createPostRequest = () => ({
  type: CREATE_POST_REQUEST,
});

const createPostSuccess = (post) => ({
  type: CREATE_POST_SUCCESS,
  payload: post,
});

const createPostFailed = (error) => ({
  type: CREATE_POST_FAILED,
  payload: error,
});

export const createPost = (post) => async (dispatch) => {
  dispatch(createPostRequest());
  try {
    const { data } = await axios.post(`/posts`, post);
    if (data.success) dispatch(createPostSuccess(data));
    else dispatch(createPostFailed(data.message));
  } catch (error) {
    dispatch(createPostFailed(error));
  }
};

// ------------------------------------ DELETE POST ------------------------------------

const deletePostRequest = () => ({
  type: DELETE_POST_REQUEST,
});

const deletePostSuccess = (id) => ({
  type: DELETE_POST_SUCCESS,
  payload: id,
});

const deletePostFailed = (error) => ({
  type: DELETE_POST_FAILED,
  payload: error,
});

export const deletePost = (id) => async (dispatch) => {
  dispatch(deletePostRequest());
  try {
    const { data, status } = await axios.delete(`/posts/${id}`);
    if (status === 204) dispatch(deletePostFailed("No post found"));
    if (status === 200) {
      if (data.success) dispatch(deletePostSuccess(id));
      else dispatch(deletePostFailed(data.message));
    }
  } catch (error) {
    dispatch(deletePostFailed(error));
  }
};
