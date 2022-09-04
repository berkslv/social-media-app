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

const commentReducer = (state = initialState, action) => {
  switch (action.type) {
    case GET_COMMENTS_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case GET_COMMENTS_SUCCESS:
      return {
        ...state,
        data: state.data.concat(action.payload.data),
        totalPages: action.payload.totalPages,
        totalCount: action.payload.totalCount,
        currentPage: action.payload.currentPage,
        pageSize: action.payload.pageSize,
        hasNext: action.payload.hasNext,
        hasPrevious: action.payload.hasPrevious,
        loading: false,
      };
    case GET_COMMENTS_FAILED:
      return {
        ...state,
        error: action.payload,
        loading: false,
      };
    case LIKE_COMMENT_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case LIKE_COMMENT_SUCCESS:
      return {
        ...state,
        data: state.data.map((comment) =>
          comment.id === action.payload.data.id ? action.payload.data : comment
        ),
        loading: false,
      };
    case LIKE_COMMENT_FAILED:
      return {
        ...state,
        error: action.payload,
        loading: false,
      };
    case DISLIKE_COMMENT_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case DISLIKE_COMMENT_SUCCESS:
      return {
        ...state,
        data: state.data.map((comment) =>
          comment.id === action.payload.data.id ? action.payload.data : comment
        ),
        loading: false,
      };
    case DISLIKE_COMMENT_FAILED:
      return {
        ...state,
        error: action.payload,
        loading: false,
      };
    case CREATE_COMMENT_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case CREATE_COMMENT_SUCCESS:
      return {
        ...state,
        data: state.data.concat(action.payload.data),
        loading: false,
      };
    case CREATE_COMMENT_FAILED:
      return {
        ...state,
        error: action.payload,
        loading: false,
      };
    default:
      return state;
  }
};

export default commentReducer;
