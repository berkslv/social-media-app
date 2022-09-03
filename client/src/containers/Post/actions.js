import axios from "utils/axios";
import {
  GET_POST_REQUEST,
  GET_POST_FAILED,
  GET_POST_SUCCESS,
  GET_POSTS_REQUEST,
  GET_POSTS_FAILED,
  GET_POSTS_SUCCESS,
} from "./types";

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
    const { data } = await axios.get(
      `/posts/${id}`
    );
    dispatch(getPostSuccess(data));
  } catch (error) {
    dispatch(getPostFailed(error));
  }
};

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

export const getPosts = () => async (dispatch) => {
  dispatch(getPostsRequest());
  try {
    const { data } = await axios.get(
      "/posts"
    );
    dispatch(getPostsSuccess(data));
  } catch (error) {
    dispatch(getPostsFailed(error));
  }
};
