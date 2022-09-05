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

const initialState = {
  isAuthenticated: false,
  token: null,
  user: {},
  error: null,
  loading: false,
};

const appReducer = (state = initialState, action) => {
  switch (action.type) {
    case SET_TOKEN:
      return {
        ...state,
        token: action.payload,
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
        user: action.payload.data.user,
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
