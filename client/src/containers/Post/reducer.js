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

const initialState = {
  data: [],
  totalPages: 0,
  totalCount: 0,
  currentPage: 0,
  pageSize: 0,
  hasNext: false,
  hasPrevious: false,
  error: null,
  loading: false,
};

const postReducer = (state = initialState, action) => {
  switch (action.type) {
    case GET_POST_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case GET_POST_SUCCESS:
      return {
        ...state,
        loading: false,
        data: state.data.concat(action.payload.data),
      };
    case GET_POST_FAILED:
      return {
        ...state,
        loading: false,
        error: action.payload,
      };
    case GET_POSTS_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case GET_POSTS_SUCCESS:
      return {
        ...state,
        loading: false,
        data: state.data.concat(action.payload.data),
        totalPages: action.payload.totalPages,
        totalCount: action.payload.totalCount,
        currentPage: action.payload.currentPage,
        pageSize: action.payload.pageSize,
        hasNext: action.payload.hasNext,
        hasPrevious: action.payload.hasPrevious,
      };
    case GET_POSTS_FAILED:
      return {
        ...state,
        loading: false,
        error: action.payload,
      };
    case LIKE_POST_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case LIKE_POST_SUCCESS:
      return {
        ...state,
        loading: false,
        data: state.data.map((post) =>
          post.id === action.payload.data.id ? action.payload.data : post
        ),
      };
    case LIKE_POST_FAILED:
      return {
        ...state,
        loading: false,
        error: action.payload,
      };
    case DISLIKE_POST_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case DISLIKE_POST_SUCCESS:
      return {
        ...state,
        loading: false,
        data: state.data.map((post) =>
          post.id === action.payload.data.id ? action.payload.data : post
        ),
      };
    case DISLIKE_POST_FAILED:
      return {
        ...state,
        loading: false,
        error: action.payload,
      };
    case CREATE_POST_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case CREATE_POST_SUCCESS:
      return {
        ...state,
        loading: false,
        data: state.data.concat(action.payload.data),
      };
    case CREATE_POST_FAILED:
      return {
        ...state,
        loading: false,
        error: action.payload,
      };
    case DELETE_POST_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case DELETE_POST_SUCCESS:
      return {
        ...state,
        loading: false,
        data: state.data.filter((post) => post.id !== action.payload),
      };
    case DELETE_POST_FAILED:
      return {
        ...state,
        loading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export default postReducer;
