import * as React from "react";
import {
  Create,
  SimpleForm,
  TextInput,
} from "react-admin";

export const DepartmentCodeCreate = ({ permissions, ...props }) => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput source="name" />
      </SimpleForm>
    </Create>
  );
};
