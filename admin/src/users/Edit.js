import * as React from "react";
import {
  Edit,
  SimpleForm,
  TextInput,
  ReferenceInput,
  SelectInput,
} from "react-admin";

export const UserEdit = ({ permissions, ...props }) => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput source="id" />
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
    </Edit>
  );
};
