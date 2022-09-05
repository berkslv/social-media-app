import axios from "utils/axios";
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

// ------------------------------------ GET UNIVERSITIES ------------------------------------

export const getUniversitiesRequest = () => ({
    type: GET_UNIVERSITIES_REQUEST,
});

export const getUniversitiesSuccess = (universities) => ({
    type: GET_UNIVERSITIES_SUCCESS,
    payload: universities,
});

export const getUniversitiesFailure = (error) => ({
    type: GET_UNIVERSITIES_FAILURE,
    payload: error,
});

export const getUniversities = () => async (dispatch) => {
    dispatch(getUniversitiesRequest());
    try {
        const { data } = await axios.get("/universities");
        dispatch(getUniversitiesSuccess(data));
    } catch (error) {
        dispatch(getUniversitiesFailure(error));
    }
}

// ------------------------------------ GET FACULTIES ------------------------------------

export const getFacultiesRequest = () => ({
    type: GET_FACULTIES_REQUEST,
});

export const getFacultiesSuccess = (faculties) => ({
    type: GET_FACULTIES_SUCCESS,
    payload: faculties,

});

export const getFacultiesFailure = (error) => ({
    type: GET_FACULTIES_FAILURE,
    payload: error,
});

export const getFaculties = (universityId) => async (dispatch) => {
    dispatch(getFacultiesRequest());
    try {
        const { data } = await axios.get(`/universities/${universityId}/faculties`);
        dispatch(getFacultiesSuccess(data));
    } catch (error) {
        dispatch(getFacultiesFailure(error));
    }
}

// ------------------------------------ GET DEPARTMENTS ------------------------------------

export const getDepartmentsRequest = () => ({
    type: GET_DEPARTMENTS_REQUEST,
});

export const getDepartmentsSuccess = (departments) => ({
    type: GET_DEPARTMENTS_SUCCESS,
    payload: departments,
});

export const getDepartmentsFailure = (error) => ({
    type: GET_DEPARTMENTS_FAILURE,
    payload: error,
});

export const getDepartments = (facultyId) => async (dispatch) => {
    dispatch(getDepartmentsRequest());
    try {
        const { data } = await axios.get(`/departments?facultyId=${facultyId}`);
        dispatch(getDepartmentsSuccess(data));
    } catch (error) {
        dispatch(getDepartmentsFailure(error));
    }
}
