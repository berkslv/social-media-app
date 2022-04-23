import * as React from "react";
import {
  Edit,
  SimpleForm,
  TextInput,
  ReferenceArrayInput,
  SelectArrayInput,
} from "react-admin";

export const PostEdit = ({ permissions, ...props }) => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput source="id" />
        <TextInput source="content" />
        <ReferenceArrayInput source="tagId" reference="tags">
          <SelectArrayInput optionText="name" />
        </ReferenceArrayInput>
      </SimpleForm>
    </Edit>
  );
};
