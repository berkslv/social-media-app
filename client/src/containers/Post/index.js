import React, { useEffect } from "react";
import { connect } from "react-redux";
import { getPosts, likePost, dislikePost } from "./actions";
import Header from "components/Header";
import PostCard from "components/PostCard";
import Container from "components/Container";
import Loading from "components/Loading";
import InfiniteScroll from "react-infinite-scroll-component";
import Create from "./Create";
import { selectPostOrderByCreated } from "./selector";

function Post({ posts, data, getPosts, likePost, dislikePost }) {
  useEffect(() => {
    if (posts.data.length === 0) {
      getPosts();
    } else if (posts.data.length === 1) {
      window.location.reload();
    }
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [data]);

  return (
    <>
      <Header />
      <Container>
        <Create />
        <InfiniteScroll
          dataLength={posts.data.length} //This is important field to render the next data
          next={getPosts}
          hasMore={posts.hasNext}
          loader={<Loading />}
          endMessage={
            <p style={{ textAlign: "center" }}>
              <b>Yay! You have seen it all</b>
            </p>
          }
        >
          {data.map((post) => (
            <div key={post.id}>
              <PostCard
                type="post"
                post={post}
                likeAction={likePost}
                dislikeAction={dislikePost}
              />
            </div>
          ))}
        </InfiniteScroll>
      </Container>
    </>
  );
}

const mapStateToProps = (state) => {
  return {
    posts: state.posts,
    data: selectPostOrderByCreated(state),
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    getPosts: () => dispatch(getPosts()),
    likePost: (id) => dispatch(likePost(id)),
    dislikePost: (id) => dispatch(dislikePost(id)),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Post);
