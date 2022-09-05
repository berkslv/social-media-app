import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { BrowserRouter as Router, useRoutes } from "react-router-dom";
import Login from "containers/App/Login";
import Register from "containers/App/Register";
import Post from "containers/Post";
import PostDetail from "containers/Post/Detail";
import Profile from "containers/Profile";
import { setToken } from "./actions";

function App() {
  const dispatch = useDispatch();
  const app = useSelector((state) => state.app);

  useEffect(() => {
    dispatch(setToken());
  }, []);

  let Route = null;

  if (app.isAuthenticated) {
    Route = () =>
      useRoutes([
        { path: "/", element: <Post /> },
        { path: "/feed", element: <Post /> },
        { path: "/feed/:id", element: <PostDetail /> },
        { path: "/profile", element: <Profile /> },
        { path: "/login", element: <Login /> },
        { path: "/register", element: <Register /> },
      ]);
  } else {
    Route = () =>
      useRoutes([
        { path: "/", element: <Login /> },
        { path: "/login", element: <Login /> },
        { path: "/register", element: <Register /> },
      ]);
  }

  return (
    <>
      <Router>
        <Route />
      </Router>
    </>
  );
}

export default App;
