import axios from "utils/axios";
import {
  GET_COMMENTS_REQUEST,
  GET_COMMENTS_SUCCESS,
  GET_COMMENTS_FAILED,
  LIKE_COMMENT_REQUEST,
  LIKE_COMMENT_SUCCESS,
  LIKE_COMMENT_FAILED,
  DISLIKE_COMMENT_REQUEST,
  DISLIKE_COMMENT_SUCCESS,
  DISLIKE_COMMENT_FAILED,
  CREATE_COMMENT_REQUEST,
  CREATE_COMMENT_SUCCESS,
  CREATE_COMMENT_FAILED
} from "./types";

// ------------------------------------ GET COMMENTS ------------------------------------

export const getCommentsRequest = () => ({
  type: GET_COMMENTS_REQUEST,
});

export const getCommentsSuccess = (data) => ({
  type: GET_COMMENTS_SUCCESS,
  payload: data,
});

export const getCommentsFaied = (error) => ({
  type: GET_COMMENTS_FAILED,
  payload: error,
});

export const getComments = (id) => async (dispatch) => {
  dispatch(getCommentsRequest());
  try {
    const { data } = await axios.get(`/posts/${id}/comments`);
    dispatch(getCommentsSuccess(data));
  } catch (error) {
    dispatch(getCommentsFaied(error));
  }
};

// ------------------------------------ LIKE COMMENT ------------------------------------

export const likeCommentRequest = () => ({
  type: LIKE_COMMENT_REQUEST,
});

export const likeCommentSuccess = (data) => ({
  type: LIKE_COMMENT_SUCCESS,
  payload: data,
});

export const likeCommentFailed = (error) => ({
  type: LIKE_COMMENT_FAILED,
  payload: error,
});

export const likeComment = (id) => async (dispatch) => {
  dispatch(likeCommentRequest());
  try {
    const { data } = await axios.put(`/comments/${id}/like`);
    dispatch(likeCommentSuccess(data));
  } catch (error) {
    dispatch(likeCommentFailed(error));
  }
}

// ------------------------------------ DISLIKE COMMENT ------------------------------------

export const dislikeCommentRequest = () => ({
  type: DISLIKE_COMMENT_REQUEST,
});

export const dislikeCommentSuccess = (data) => ({
  type: DISLIKE_COMMENT_SUCCESS,
  payload: data,
});

export const dislikeCommentFailed = (error) => ({
  type: DISLIKE_COMMENT_FAILED,
  payload: error,
});

export const dislikeComment = (id) => async (dispatch) => {
  dispatch(dislikeCommentRequest());
  try {
    const { data } = await axios.put(`/comments/${id}/dislike`);
    dispatch(dislikeCommentSuccess(data));
  } catch (error) {
    dispatch(dislikeCommentFailed(error));
  }
}

// ------------------------------------ CREATE COMMENT ------------------------------------

export const createCommentRequest = () => ({
  type: CREATE_COMMENT_REQUEST,
});

export const createCommentSuccess = (data) => ({
  type: CREATE_COMMENT_SUCCESS,
  payload: data,
});

export const createCommentFailed = (error) => ({
  type: CREATE_COMMENT_FAILED,
  payload: error,
});

export const createComment = (post) => async (dispatch) => {
  dispatch(createCommentRequest());
  try {
    const { data } = await axios.post("/comments", post);
    dispatch(createCommentSuccess(data));
  } catch (error) {
    dispatch(createCommentFailed(error));
  }
}