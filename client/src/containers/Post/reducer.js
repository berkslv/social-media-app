import {
  GET_POST_REQUEST,
  GET_POST_FAILED,
  GET_POST_SUCCESS,
  GET_POSTS_REQUEST,
  GET_POSTS_FAILED,
  GET_POSTS_SUCCESS,
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

const postsReducer = (state = initialState, action) => {
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
    default:
      return state;
  }
};

export default postsReducer;