import React, { useEffect } from "react";
import Header from "containers/Header";
import Container from "components/Container";
import { useParams } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";
import { getUser, selectUser } from "./actions";
import Loading from "components/Loading";
import Profile from "components/Profile";
import { selectUserById, selectUserPost } from "./selector";
import InfiniteScroll from "react-infinite-scroll-component";
import {
  deletePost,
  dislikePost,
  getPosts,
  likePost,
} from "containers/Post/actions";
import PostCard from "components/PostCard";

function User() {
  const { id } = useParams();
  const dispatch = useDispatch();
  const app = useSelector((state) => state.app);
  const user = useSelector((state) => state.user);
  const data = useSelector((state) => selectUserById(state, id));
  const post = useSelector((state) => state.post);
  const posts = useSelector((state) => selectUserPost(state, id));

  useEffect(() => {
    dispatch(selectUser(id));
    if (data === undefined) {
      dispatch(getUser(id));
    }
    if (posts.length === 0) {
      dispatch(getPosts());
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <>
      <Header />
      <Container>
        {user.loading ? (
          <Loading fullscreen />
        ) : user.error ? (
          <p>{user.error}</p>
        ) : (
          <>
            {data && <Profile user={data} />}
            <InfiniteScroll
              dataLength={post.data.length} //This is important field to render the next data
              next={() => dispatch(getPosts)}
              hasMore={post.hasNext}
              loader={<Loading />}
              endMessage={
                <p style={{ textAlign: "center" }}>
                  <b>Yay! You have seen it all</b>
                </p>
              }
            >
              {posts.map((post) => (
                <PostCard
                  user={app.user}
                  key={post.id}
                  type="post"
                  post={post}
                  likeAction={(id) => dispatch(likePost(id))}
                  dislikeAction={(id) => dispatch(dislikePost(id))}
                  deleteAction={(id) => dispatch(deletePost(id))}
                />
              ))}
            </InfiniteScroll>
          </>
        )}
      </Container>
    </>
  );
}
export default User;
