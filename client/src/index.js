import ReactDOM from "react-dom/client";
import { BrowserRouter as Router, useRoutes } from "react-router-dom";
import { Provider } from "react-redux";
import store from "./store";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min";

import Login from "containers/Login";
import Post from "containers/Post";
import PostDetail from "containers/Post/Detail";
import Register from "containers/Register";
import Profile from "containers/Profile";

const root = ReactDOM.createRoot(document.getElementById("root"));

const Route = () =>
  useRoutes([
    { path: "/", element: <Post /> },
    { path: "/feed", element: <Post /> },
    { path: "/feed/:id", element: <PostDetail /> },
    { path: "/profile", element: <Profile /> },
    { path: "/login", element: <Login /> },
    { path: "/register", element: <Register /> },
  ]);

root.render(
  <Provider store={store}>
    <Router>
      <Route />
    </Router>
  </Provider>
);
