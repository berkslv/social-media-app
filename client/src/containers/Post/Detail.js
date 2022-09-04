import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { useParams } from "react-router-dom";
import { getPost, likePost, dislikePost } from "containers/Post/actions";
import Header from "components/Header";
import Card from "components/Card";
import Container from "components/Container";
import Loading from "components/Loading";
// import InfiniteScroll from "react-infinite-scroll-component";
import { selectPostById } from "containers/Post/selector";

function PostDetail() {
  const { id } = useParams();

  const posts = useSelector((state) => state.posts.data);
  const post = useSelector((state) => selectPostById(state, id));
  const dispatch = useDispatch();

  useEffect(() => {
    if (post === undefined) {
      dispatch(getPost(id));
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch]);

  return (
    <>
      <Header />
      <Container>
        {posts.loading ? (
          <Loading />
        ) : (
          post && (
            
            <Card
              type="post"
              post={post}
              likeAction={(id) => dispatch(likePost(id))}
              dislikeAction={(id) => dispatch(dislikePost(id))}
            />
          )
        )}
      </Container>
    </>
  );
}

export default PostDetail;
