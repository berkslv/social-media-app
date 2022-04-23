import * as React from "react";
import {
  Edit,
  SimpleForm,
  TextInput,
  ReferenceInput,
  SelectInput
} from "react-admin";

export const FacultyEdit = ({ permissions, ...props }) => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput source="id" />
        <TextInput source="name" />
        <TextInput source="latitude" />
        <TextInput source="altitude" />
        <TextInput source="address" />
        <ReferenceInput source="universityId" reference="universities">
          <SelectInput optionText="name" />
        </ReferenceInput>
      </SimpleForm>
    </Edit>
  );
};
