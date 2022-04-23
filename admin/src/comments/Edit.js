import * as React from "react";
import {
  Edit,
  SimpleForm,
  TextInput,
  ReferenceInput,
  SelectInput,
} from "react-admin";

export const CommentEdit = ({ permissions, ...props }) => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput source="id" />
        <TextInput source="content" />
        <ReferenceInput source="postId" reference="posts">
          <SelectInput optionText="id" />
        </ReferenceInput>
      </SimpleForm>
    </Edit>
  );
};
