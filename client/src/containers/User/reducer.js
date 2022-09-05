import {
  GET_USER_REQUEST,
  GET_USER_SUCCESS,
  GET_USER_FAILURE,
  SELECT_USER,
  DESELECT_USER,
} from "./types";

const initialState = {
  data: [],
  selectedUserId: null,
  totalPages: 0,
  totalCount: 0,
  currentPage: 0,
  pageSize: 0,
  hasNext: false,
  hasPrevious: false,
  error: null,
  loading: true,
};

export default function userReducer(state = initialState, action) {
  switch (action.type) {
    case GET_USER_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case GET_USER_SUCCESS:
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
    case GET_USER_FAILURE:
      return {
        ...state,
        loading: false,
        error: action.payload,
      };
    case SELECT_USER:
        return {
            ...state,
            selectedUserId: action.payload,
        };
    case DESELECT_USER:
        return {
            ...state,
            selectedUserId: null,
        };
    default:
      return state;
  }
}
