import React, { useEffect } from "react";
import { connect } from "react-redux";
import { getPosts } from "./actions";
import Header from "components/Header";
import Card from "components/Card";
import Container from "components/Container";
import Loading from "components/Loading";

function Post({ posts, getPosts }) {
  useEffect(() => {
    getPosts();
  }, [getPosts]);

  return (
    <>
      <Header />
      <Container>
        {posts.loading ? (
          <Loading />
        ) : (
          <div>
            <h1>Posts</h1>
            {posts.data.map((post) => (
              <div key={post.id}>
                <Card
                  type="post"
                  title={post.username}
                  time={post.created}
                  content={post.content}
                  like={post.like}
                  dislike={post.dislike}
                />
              </div>
            ))}
          </div>
        )}
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
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Post);
