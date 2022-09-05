import React, { useEffect } from "react";
import { connect } from "react-redux";
import { getPosts, likePost, dislikePost } from "./actions";
import Header from "containers/Header";
import PostCard from "components/PostCard";
import Container from "components/Container";
import Loading from "components/Loading";
import InfiniteScroll from "react-infinite-scroll-component";
import Create from "./Create";
import { selectPost } from "./selector";
import Tag from "containers/Tag";

function Post({ post, data, getPosts, likePost, dislikePost }) {
  useEffect(() => {
    if (post.data.length === 0) {
      getPosts();
    } else if (post.data.length === 1) {
      window.location.reload();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [data]);

  return (
    <>
      <Header />
      <Container>
        <Tag />
        <Create />
        <InfiniteScroll
          dataLength={post.data.length} //This is important field to render the next data
          next={getPosts}
          hasMore={post.hasNext}
          loader={<Loading />}
          endMessage={
            <p style={{ textAlign: "center" }}>
              <b>Yay! You have seen it all</b>
            </p>
          }
        >
          {data.map((post) => (
            <PostCard
              key={post.id}
              type="post"
              post={post}
              likeAction={likePost}
              dislikeAction={dislikePost}
            />
          ))}
        </InfiniteScroll>
      </Container>
    </>
  );
}

const mapStateToProps = (state) => {
  return {
    post: state.post,
    data: selectPost(state),
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
