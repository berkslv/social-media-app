import axios from "utils/axios";
import {
  GET_USER_REQUEST,
  GET_USER_SUCCESS,
  GET_USER_FAILURE,
  SELECT_USER,
  DESELECT_USER,
} from "./types";

// ------------------------------------ GET USER ------------------------------------

export const getUserRequest = () => ({
  type: GET_USER_REQUEST,
});

export const getUserSuccess = (payload) => ({
  type: GET_USER_SUCCESS,
  payload,
});

export const getUserFailure = (payload) => ({
  type: GET_USER_FAILURE,
  payload,
});

export const getUser = (id) => async (dispatch) => {
  dispatch(getUserRequest());
  try {
    const { data, status } = await axios.get(`/users/${id}`);
    if (status === 204) dispatch(getUserFailure("No user found"));
    if (status === 200) {
      if (data.success) dispatch(getUserSuccess(data));
      else dispatch(getUserFailure(data.message));
    }
  } catch (error) {
    dispatch(getUserFailure(error));
  }
};

// ------------------------------------ SELECT USER ------------------------------------

export const selectUser = (id) => ({
  type: SELECT_USER,
  payload: id,
});

// ------------------------------------ DESELECT USER ------------------------------------

export const deselectUser = () => ({
    type: DESELECT_USER,
});