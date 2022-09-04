import axios from "utils/axios";
import {
    GET_TAGS_REQUEST,
    GET_TAGS_SUCCESS,
    GET_TAGS_FAILED,
    SELECT_TAG,
    DESELECT_TAG,
} from "./types";

// ------------------------------------ GET TAGS ------------------------------------

export const getTagsRequest = () => ({
    type: GET_TAGS_REQUEST,
});

export const getTagsSuccess = (tags) => ({
    type: GET_TAGS_SUCCESS,
    payload: tags,
});

export const getTagsFailed = (error) => ({
    type: GET_TAGS_FAILED,
    payload: error,
});

export const getTags = () => async (dispatch) => {
    dispatch(getTagsRequest());
    try {
        const { data } = await axios.get("/tags");
        dispatch(getTagsSuccess(data));
    } catch (error) {
        dispatch(getTagsFailed(error));
    }
}

// ------------------------------------ SELECT TAG ------------------------------------

export const selectTag = (tagId) => (dispatch) => {
    dispatch({
        type: SELECT_TAG,
        payload: tagId,
    });
}

// ------------------------------------ DESELECT TAG ------------------------------------

export const deselectTag = () => (dispatch) => {
    dispatch({
        type: DESELECT_TAG,
    });
}
