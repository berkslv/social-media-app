import { combineReducers } from "redux";
import postReducer from "containers/Post/reducer";
import tagReducer from "containers/Tag/reducer";
import commentReducer from "containers/Comment/reducer";

const rootReducer = combineReducers({
    post: postReducer,
    tag: tagReducer,
    comment: commentReducer,
});

export default rootReducer;