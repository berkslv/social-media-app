import * as React from "react";
import {
  Create,
  SimpleForm,
  TextInput,
  ReferenceInput,
  SelectInput
} from "react-admin";

export const CommentCreate = ({ permissions, ...props }) => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput source="content" />
        <ReferenceInput source="postId" reference="posts">
          <SelectInput optionText="id" />
        </ReferenceInput>
      </SimpleForm>
    </Create>
  );
};
