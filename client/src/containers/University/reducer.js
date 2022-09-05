import {
  GET_UNIVERSITIES_REQUEST,
  GET_UNIVERSITIES_SUCCESS,
  GET_UNIVERSITIES_FAILURE,
  GET_FACULTIES_REQUEST,
  GET_FACULTIES_SUCCESS,
  GET_FACULTIES_FAILURE,
  GET_DEPARTMENTS_REQUEST,
  GET_DEPARTMENTS_SUCCESS,
  GET_DEPARTMENTS_FAILURE,
} from "./types";

const initialState = {
  universities: [],
  faculties: [],
  departments: [],
  totalPages: 0,
  totalCount: 0,
  currentPage: 0,
  pageSize: 0,
  hasNext: false,
  hasPrevious: false,
  error: null,
  loading: false,
};


export default function universityReducer(state = initialState, action) {
    switch (action.type) {
        case GET_UNIVERSITIES_REQUEST:
        return {
            ...state,
            loading: true,
        };
        case GET_UNIVERSITIES_SUCCESS:
        return {
            ...state,
            loading: false,
            universities: action.payload.data,
            totalPages: action.payload.totalPages,
            totalCount: action.payload.totalCount,
            currentPage: action.payload.currentPage,
            pageSize: action.payload.pageSize,
            hasNext: action.payload.hasNext,
            hasPrevious: action.payload.hasPrevious,
        };
        case GET_UNIVERSITIES_FAILURE:
        return {
            ...state,
            loading: false,
            error: action.payload.error,
        };
        case GET_FACULTIES_REQUEST:
        return {
            ...state,
            loading: true,
        };
        case GET_FACULTIES_SUCCESS:
        return {
            ...state,
            loading: false,
            faculties: action.payload.data,
            totalPages: action.payload.totalPages,
            totalCount: action.payload.totalCount,
            currentPage: action.payload.currentPage,
            pageSize: action.payload.pageSize,
            hasNext: action.payload.hasNext,
            hasPrevious: action.payload.hasPrevious,
        };
        case GET_FACULTIES_FAILURE:
        return {
            ...state,
            loading: false,
            error: action.payload.error,
        };
        case GET_DEPARTMENTS_REQUEST:
        return {
            ...state,
            loading: true,
        };
        case GET_DEPARTMENTS_SUCCESS:
        return {
            ...state,
            loading: false,
            departments: action.payload.data,
            totalPages: action.payload.totalPages,
            totalCount: action.payload.totalCount,
            currentPage: action.payload.currentPage,
            pageSize: action.payload.pageSize,
            hasNext: action.payload.hasNext,
            hasPrevious: action.payload.hasPrevious,
        };
        case GET_DEPARTMENTS_FAILURE:
        return {
            ...state,
            loading: false,
            error: action.payload.error,
        };
        default:
        return state;
    }
}