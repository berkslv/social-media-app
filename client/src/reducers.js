import { combineReducers } from "redux";
import appReducer from "containers/App/reducer";
import postReducer from "containers/Post/reducer";
import tagReducer from "containers/Tag/reducer";
import commentReducer from "containers/Comment/reducer";
import universityReducer from "containers/University/reducer";

const rootReducer = combineReducers({
    app: appReducer,
    post: postReducer,
    tag: tagReducer,
    comment: commentReducer,
    university: universityReducer,
});

export default rootReducer;