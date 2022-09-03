import { combineReducers } from "redux";
import postsReducer from "containers/Post/reducer";

const rootReducer = combineReducers({
    posts: postsReducer,
});

export default rootReducer;