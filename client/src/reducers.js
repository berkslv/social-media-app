import { combineReducers } from "redux";
import postReducer from "containers/Post/reducer";
import tagReducer from "containers/Tag/reducer";

const rootReducer = combineReducers({
    post: postReducer,
    tag: tagReducer,
});

export default rootReducer;