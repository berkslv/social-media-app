import axios from "utils/axios";
import {
    GET_TAGS_REQUEST,
    GET_TAGS_SUCCESS,
    GET_TAGS_FAILED,
    SELECT_TAG,
    DESELECT_TAG,
} from "./types";

// ------------------------------------ GET TAGS ------------------------------------

const getTagsRequest = () => ({
    type: GET_TAGS_REQUEST,
});

const getTagsSuccess = (tags) => ({
    type: GET_TAGS_SUCCESS,
    payload: tags,
});

const getTagsFailed = (error) => ({
    type: GET_TAGS_FAILED,
    payload: error,
});

export const getTags = () => async (dispatch) => {
    dispatch(getTagsRequest());
    try {
        const { data } = await axios.get("/tags");
        if (data.success) dispatch(getTagsSuccess(data));
        else dispatch(getTagsFailed(data.message));
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
