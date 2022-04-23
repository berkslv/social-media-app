import * as React from "react";
import {
  List,
  Datagrid,
  EditButton,
  TextField,
  ReferenceField,
  ReferenceArrayField,
  SingleFieldList,
  ChipField,
  SimpleList,
} from "react-admin";
import { useMediaQuery } from "@material-ui/core";
import Unauthorized from "../shared/Unauthorized";

export const PostList = ({ permissions, ...props }) => {
  const isSmall = useMediaQuery((theme) => theme.breakpoints.down("sm"));

  if (permissions === undefined) {
    return <Unauthorized />;
  }

  if (permissions.includes("Admin") || permissions.includes("Student")) {
    return (
      <List {...props} perPage={10}>
        {isSmall ? (
          <SimpleList
            primaryText={(record) => record.content}
            secondaryText={
              <ReferenceField source="authorId" reference="users">
                <TextField source="name" />
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
            <ReferenceArrayField label="Tags" source="tagId" reference="tags">
              <SingleFieldList>
                <ChipField source="name" />
              </SingleFieldList>
            </ReferenceArrayField>
            <EditButton />
          </Datagrid>
        )}
      </List>
    );
  } else {
    return <Unauthorized />;
  }
};
