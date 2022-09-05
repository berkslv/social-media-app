import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { BrowserRouter as Router, useRoutes } from "react-router-dom";
import Login from "containers/App/Login";
import Register from "containers/App/Register";
import Post from "containers/Post";
import PostDetail from "containers/Post/Detail";
import User from "containers/User";
import { setToken } from "./actions";
import Logout from "containers/App/Logout";
import Verify from "containers/App/Verify";

function App() {
  const dispatch = useDispatch();
  const app = useSelector((state) => state.app);

  useEffect(() => {
    dispatch(setToken());
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  let Route = null;

  if (app.isAuthenticated) {
    Route = () =>
      useRoutes([
        { path: "/", element: <Post /> },
        { path: "/feed", element: <Post /> },
        { path: "/feed/:id", element: <PostDetail /> },
        { path: "/user/:id", element: <User /> },
        { path: "/login", element: <Login /> },
        { path: "/logout", element: <Logout /> },
        { path: "/register", element: <Register /> },
      ]);
  } else {
    Route = () =>
      useRoutes([
        { path: "/", element: <Login /> },
        { path: "/login", element: <Login /> },
        { path: "/register", element: <Register /> },
        { path: "/verify", element: <Verify /> },
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
