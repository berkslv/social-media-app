import {
  GET_TAGS_REQUEST,
  GET_TAGS_SUCCESS,
  GET_TAGS_FAILED,
  SELECT_TAG,
  DESELECT_TAG,
} from "./types";

const initialState = {
  selectedTagId: null,
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

export default function tagReducer(state = initialState, action) {
  switch (action.type) {
    case GET_TAGS_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case GET_TAGS_SUCCESS:
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
    case GET_TAGS_FAILED:
      return {
        ...state,
        error: action.payload,
        loading: false,
      };
    case SELECT_TAG:
      return {
        ...state,
        selectedTagId: action.payload,
      };
    case DESELECT_TAG:
      return {
        ...state,
        selectedTagId: null,
      };
    default:
      return state;
  }
}
