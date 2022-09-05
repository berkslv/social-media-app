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

const getUniversitiesRequest = () => ({
  type: GET_UNIVERSITIES_REQUEST,
});

const getUniversitiesSuccess = (universities) => ({
  type: GET_UNIVERSITIES_SUCCESS,
  payload: universities,
});

const getUniversitiesFailure = (error) => ({
  type: GET_UNIVERSITIES_FAILURE,
  payload: error,
});

export const getUniversities = () => async (dispatch) => {
  dispatch(getUniversitiesRequest());
  try {
    const { data, status } = await axios.get("/universities");

    if (status === 204) dispatch(getUniversitiesFailure("No university found"));
    if (status === 200) {
      if (data.success) dispatch(getUniversitiesSuccess(data));
      else dispatch(getUniversitiesFailure(data.message));
    }
  } catch (error) {
    dispatch(getUniversitiesFailure(error));
  }
};

// ------------------------------------ GET FACULTIES ------------------------------------

const getFacultiesRequest = () => ({
  type: GET_FACULTIES_REQUEST,
});

const getFacultiesSuccess = (faculties) => ({
  type: GET_FACULTIES_SUCCESS,
  payload: faculties,
});

const getFacultiesFailure = (error) => ({
  type: GET_FACULTIES_FAILURE,
  payload: error,
});

export const getFaculties = (universityId) => async (dispatch) => {
  dispatch(getFacultiesRequest());
  try {
    const { data, status } = await axios.get(
      `/universities/${universityId}/faculties`
    );

    if (status === 204) dispatch(getFacultiesFailure("No faculty found"));
    if (status === 200) {
      if (data.success) dispatch(getFacultiesSuccess(data));
      else dispatch(getFacultiesFailure(data.message));
    }
  } catch (error) {
    dispatch(getFacultiesFailure(error));
  }
};

// ------------------------------------ GET DEPARTMENTS ------------------------------------

const getDepartmentsRequest = () => ({
  type: GET_DEPARTMENTS_REQUEST,
});

const getDepartmentsSuccess = (departments) => ({
  type: GET_DEPARTMENTS_SUCCESS,
  payload: departments,
});

const getDepartmentsFailure = (error) => ({
  type: GET_DEPARTMENTS_FAILURE,
  payload: error,
});

export const getDepartments = (facultyId) => async (dispatch) => {
  dispatch(getDepartmentsRequest());
  try {
    const { data, status } = await axios.get(
      `/departments?facultyId=${facultyId}`
    );

    if (status === 204) dispatch(getDepartmentsFailure("No department found"));
    if (status === 200) {
      if (data.success) dispatch(getDepartmentsSuccess(data));
      else dispatch(getDepartmentsFailure(data.message));
    }
  } catch (error) {
    dispatch(getDepartmentsFailure(error));
  }
};
