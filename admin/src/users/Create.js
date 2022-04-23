import * as React from "react";
import {
  Create,
  SimpleForm,
  TextInput,
  ReferenceInput,
  SelectInput,
} from "react-admin";

export const UserCreate = ({ permissions, ...props }) => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput source="name" />
        <TextInput source="email" />
        <TextInput source="username" />
        <TextInput source="password" />
        <TextInput source="role" />
        <ReferenceInput source="universityId" reference="universities">
          <SelectInput source="name" />
        </ReferenceInput>
        <ReferenceInput source="facultyId" reference="faculties">
          <SelectInput source="name" />
        </ReferenceInput>
        <ReferenceInput source="departmentId" reference="departments">
          <SelectInput source="name" />
        </ReferenceInput>
      </SimpleForm>
    </Create>
  );
};
