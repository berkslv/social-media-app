import React, { useEffect } from "react";
import { connect } from "react-redux";
import { getPosts, likePost, dislikePost } from "./actions";
import Header from "components/Header";
import Card from "components/Card";
import Container from "components/Container";
import Loading from "components/Loading";
import InfiniteScroll from "react-infinite-scroll-component";

function Post({ posts, getPosts, likePost, dislikePost }) {
  useEffect(() => {
    getPosts();
  }, [getPosts]);

  return (
    <>
      <Header />
      <Container>
        <InfiniteScroll
          dataLength={posts.data.length} //This is important field to render the next data
          next={getPosts}
          hasMore={posts.hasNext}
          loader={<h4>Loading...</h4>}
          endMessage={
            <p style={{ textAlign: "center" }}>
              <b>Yay! You have seen it all</b>
            </p>
          }
        >
          {posts.data.map((post) => (
            <div key={post.id}>
              <Card
                type="post"
                id={post.id}
                title={post.username}
                time={post.created}
                content={post.content}
                like={post.like}
                likeAction={likePost}
                dislike={post.dislike}
                dislikeAction={dislikePost}
                tags={post.tags}
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
