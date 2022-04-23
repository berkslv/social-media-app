import * as React from "react";
import {
  Edit,
  SimpleForm,
  TextInput,
} from "react-admin";

export const TagEdit = ({ permissions, ...props }) => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput source="id" />
        <TextInput source="name" />
        <TextInput source="description" />
      </SimpleForm>
    </Edit>
  );
};
