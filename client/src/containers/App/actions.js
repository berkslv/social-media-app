import axios from "utils/axios";
import {
  LOGIN_REQUEST,
  LOGIN_SUCCESS,
  LOGIN_FAILURE,
  WHOAMI_REQUEST,
  WHOAMI_SUCCESS,
  WHOAMI_FAILURE,
  SET_TOKEN,
  SET_TOKEN_FAILURE,
} from "./types";
import { setAuthToken } from "utils/axios";

// ------------------------------------ AUTH ------------------------------------

export const setToken = (token = null) => {
  if (token !== null) {
    setAuthToken(token);
    localStorage.setItem("token", token);
    return {
      type: SET_TOKEN,
      payload: token,
    };
  }

  token = localStorage.getItem("token");

  if (token !== null) {
    setAuthToken(token);
    return {
      type: SET_TOKEN,
      payload: token,
    };
  } else {
    return {
      type: SET_TOKEN_FAILURE,
    };
  }
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
    dispatch(setToken(data.data.token));
    dispatch(loginSuccess(data));
  } catch (error) {
    dispatch(loginFailure(error));
  }
};

// ------------------------------------ WHOAMI ------------------------------------

export const whoamiRequest = () => ({
  type: WHOAMI_REQUEST,
});

export const whoamiSuccess = (data) => ({
  type: WHOAMI_SUCCESS,
  payload: data,
});

export const whoamiFailure = (error) => ({
  type: WHOAMI_FAILURE,
  payload: error,
});

export const whoami = () => async (dispatch) => {
  dispatch(whoamiRequest());
  try {
    const { data } = await axios.get("/users/me");
    dispatch(whoamiSuccess(data));
  } catch (error) {
    dispatch(whoamiFailure(error));
  }
};
