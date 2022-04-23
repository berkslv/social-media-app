import * as React from "react";
import {
  List,
  Datagrid,
  EditButton,
  TextField,
  ReferenceField,
  SimpleList,
} from "react-admin";
import { useMediaQuery } from "@material-ui/core";
import Unauthorized from "../shared/Unauthorized";

export const CommentList = ({ permissions, ...props }) => {
  
  const isSmall = useMediaQuery((theme) => theme.breakpoints.down("sm"));

  if (permissions === undefined) {
    return <Unauthorized />;
  }

  if (permissions.includes("Admin")) {
    return (
      <List {...props} perPage={10}>
        {isSmall ? (
          <SimpleList
            primaryText={(record) => record.content}
            secondaryText={
              <ReferenceField source="postId" reference="posts">
                <TextField source="id" />
              </ReferenceField>
            }
            tertiaryText={(record) => record.id}
          />
        ) : (
          <Datagrid>
            <TextField source="id" />
            <TextField source="content" />
            <TextField source="like" sortable={false} />
            <TextField source="dislike" sortable={false} />
            <ReferenceField source="authorId" reference="users">
              <TextField source="name" />
            </ReferenceField>
            <ReferenceField source="postId" reference="posts">
              <TextField source="id" />
            </ReferenceField>
            <EditButton />
          </Datagrid>
        )}
      </List>
    );
  } else {
    return <Unauthorized />;
  }
};
