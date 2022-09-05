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
  CREATE_COMMENT_FAILED,
} from "./types";

// ------------------------------------ GET COMMENTS ------------------------------------

const getCommentsRequest = () => ({
  type: GET_COMMENTS_REQUEST,
});

const getCommentsSuccess = (data) => ({
  type: GET_COMMENTS_SUCCESS,
  payload: data,
});

const getCommentsFaied = (error) => ({
  type: GET_COMMENTS_FAILED,
  payload: error,
});

export const getComments = (id) => async (dispatch, getState) => {
  dispatch(getCommentsRequest());
  try {
    const currentPage = getState().comment.currentPage;

    const { data, status } = await axios.get(
      `/comments?postId=${id}&pageNumber=${
        currentPage + 1
      }&orderBy=Created_desc`
    );
    if (status === 204) dispatch(getCommentsFaied("No comments found"));
    if (status === 200) {
      if (data.success) dispatch(getCommentsSuccess(data));
      else dispatch(getCommentsFaied(data.message));
    }
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
    const { data, status } = await axios.put(`/comments/${id}/like`);

    if (status === 204) dispatch(likeCommentFailed("No comment found"));
    if (status === 200) {
      if (data.success) dispatch(likeCommentSuccess(data));
      else dispatch(likeCommentFailed(data.message));
    }
  } catch (error) {
    dispatch(likeCommentFailed(error));
  }
};

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
    const { data, status } = await axios.put(`/comments/${id}/dislike`);
    if (status === 204) dispatch(likeCommentFailed("No comment found"));
    if (status === 200) {
      if (data.success) dispatch(dislikeCommentSuccess(data));
      else dispatch(dislikeCommentFailed(data.message));
    }
  } catch (error) {
    dispatch(dislikeCommentFailed(error));
  }
};

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
    if (data.success) dispatch(createCommentSuccess(data));
    else dispatch(createCommentFailed(data.message));
  } catch (error) {
    dispatch(createCommentFailed(error));
  }
};
