import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { useParams } from "react-router-dom";
import { getPost, likePost, dislikePost } from "containers/Post/actions";
import Header from "containers/Header";
import PostCard from "components/PostCard";
import Container from "components/Container";
import Loading from "components/Loading";
// import InfiniteScroll from "react-infinite-scroll-component";
import { selectPostById } from "containers/Post/selector";
import Comment from "containers/Comment";

function PostDetail() {
  const { id } = useParams();

  const app = useSelector((state) => state.app);
  const post = useSelector((state) => state.post.data);
  const data = useSelector((state) => selectPostById(state, id));
  const dispatch = useDispatch();

  useEffect(() => {
    if (data === undefined) {
      dispatch(getPost(id));
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch]);

  return (
    <>
      <Header />
      <Container>
        {post.loading ? (
          <Loading />
        ) : (
          data && (
            <>
              <PostCard
                user={app.user}
                post={data}
                likeAction={(id) => dispatch(likePost(id))}
                dislikeAction={(id) => dispatch(dislikePost(id))}
              />
              <Comment postId={data.id} />
            </>
          )
        )}
      </Container>
    </>
  );
}

export default PostDetail;
