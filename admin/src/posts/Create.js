import * as React from "react";
import {
  Create,
  SimpleForm,
  TextInput,
  ReferenceArrayInput,
  SelectArrayInput,
} from "react-admin";

export const PostCreate = ({ permissions, ...props }) => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput source="content" />
        <ReferenceArrayInput source="tagId" reference="tags">
          <SelectArrayInput optionText="name" />
        </ReferenceArrayInput>
      </SimpleForm>
    </Create>
  );
};
