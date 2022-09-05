import axios from "utils/axios";
import {
  LOGIN_REQUEST,
  LOGIN_SUCCESS,
  LOGIN_FAILURE,
  REGISTER_REQUEST,
  REGISTER_SUCCESS,
  REGISTER_FAILURE,
  VERIFY_REQUEST,
  VERIFY_SUCCESS,
  VERIFY_FAILURE,
  SET_TOKEN,
  SET_TOKEN_FAILURE,
  RESET_MESSAGE,
} from "./types";
import { setAuthToken } from "utils/axios";
import jwtDecoder from "utils/jwtDecoder";

// ------------------------------------ AUTH ------------------------------------

export const setToken = (token = null) => {
  if (token !== null) {
    setAuthToken(token);
    localStorage.setItem("token", token);
    const data = {
      token,
      user: jwtDecoder(token),
    };
    return {
      type: SET_TOKEN,
      payload: data,
    };
  }

  token = localStorage.getItem("token");

  if (token !== null) {
    setAuthToken(token);
    const data = {
      token,
      user: jwtDecoder(token),
    };
    return {
      type: SET_TOKEN,
      payload: data,
    };
  } else {
    return {
      type: SET_TOKEN_FAILURE,
    };
  }
};

export const resetToken = () => {
  localStorage.removeItem("token");
  setAuthToken();
  return {
    type: SET_TOKEN_FAILURE,
  };
};

// ------------------------------------ LOGIN ------------------------------------

export const loginRequest = () => ({
  type: LOGIN_REQUEST,
});

export const loginSuccess = (data) => ({
  type: LOGIN_SUCCESS,
  payload: data,
});

export const loginFailure = (error) => ({
  type: LOGIN_FAILURE,
  payload: error,
});

export const login = (email, password) => async (dispatch) => {
  dispatch(loginRequest());
  try {
    const { data } = await axios.post("/auth/login", { email, password });
    if (data.success) {
      dispatch(setToken(data.data.token));
      dispatch(loginSuccess(data));
    } else {
      dispatch(loginFailure(data.message));
    }
  } catch (error) {
    dispatch(loginFailure(error.response.data.message));
  }
};

// ------------------------------------ REGISTER ------------------------------------

export const registerRequest = () => ({
  type: REGISTER_REQUEST,
});

export const registerSuccess = (data) => ({
  type: REGISTER_SUCCESS,
  payload: data,
});

export const registerFailure = (error) => ({
  type: REGISTER_FAILURE,
  payload: error,
});

export const register = (model) => async (dispatch) => {
  dispatch(registerRequest());
  try {
    const { data } = await axios.post("/auth/register", model);
    if (data.success) dispatch(registerSuccess(data));
    else dispatch(registerFailure(data.message));
  } catch (error) {
    dispatch(registerFailure(error.response.data.message));
  }
};

// ------------------------------------ VERIFY ------------------------------------

export const verifyRequest = () => ({
  type: VERIFY_REQUEST,
});

export const verifySuccess = (data) => ({
  type: VERIFY_SUCCESS,
  payload: data,
});

export const verifyFailure = (error) => ({
  type: VERIFY_FAILURE,
  payload: error,
});

export const verify = (email, code) => async (dispatch) => {
  dispatch(verifyRequest());
  try {
    const { data } = await axios.post("/auth/verify", { email, code });
    if (data.success) dispatch(verifySuccess(data));
    else dispatch(verifyFailure(data.message));
  } catch (error) {
    dispatch(verifyFailure(error.response.data.message));
  }
};

// ------------------------------------ RESET MESSAGE ------------------------------------

export const resetMessage = () => ({
  type: RESET_MESSAGE,
});