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
  WHOAMI_REQUEST,
  WHOAMI_SUCCESS,
  WHOAMI_FAILURE,
  SET_TOKEN,
  SET_TOKEN_FAILURE,
} from "./types";

const initialState = {
  isAuthenticated: false,
  token: null,
  user: {},
  message: null,
  error: null,
  loading: false,
};

const appReducer = (state = initialState, action) => {
  switch (action.type) {
    case SET_TOKEN:
      return {
        ...state,
        token: action.payload.token,
        user: action.payload.user,
        isAuthenticated: true,
      };
    case SET_TOKEN_FAILURE:
      return {
        ...state,
        token: null,
        isAuthenticated: false,
      };
    case LOGIN_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case LOGIN_SUCCESS:
      return {
        ...state,
        token: action.payload.data.token,
        error: null,
        loading: false,
        isAuthenticated: true,
      };
    case LOGIN_FAILURE:
      return {
        ...state,
        error: action.payload,
        loading: false,
        isAuthenticated: false,
      };
    case REGISTER_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case REGISTER_SUCCESS:
      return {
        ...state,
        message: action.payload.message,
        error: null,
        loading: false,
      };
    case REGISTER_FAILURE:
      return {
        ...state,
        error: action.payload,
        loading: false,
        isAuthenticated: false,
      };
    case VERIFY_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case VERIFY_SUCCESS:
      return {
        ...state,
        message: action.payload.message,
        error: null,
        loading: false,
      };
    case VERIFY_FAILURE:
      return {
        ...state,
        error: action.payload,
        loading: false,
        isAuthenticated: false,
      };
    case WHOAMI_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case WHOAMI_SUCCESS:
      return {
        ...state,
        user: action.payload.data,
        loading: false,
      };
    case WHOAMI_FAILURE:
      return {
        ...state,
        error: action.payload,
        loading: false,
      };
    default:
      return state;
  }
};

export default appReducer;
