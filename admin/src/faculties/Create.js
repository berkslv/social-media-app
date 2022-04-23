import * as React from "react";
import {
  Create,
  SimpleForm,
  TextInput,
  ReferenceInput,
  SelectInput
} from "react-admin";

export const FacultyCreate = ({ permissions, ...props }) => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput source="name" />
        <TextInput source="latitude" />
        <TextInput source="altitude" />
        <TextInput source="address" />
        <ReferenceInput source="universityId" reference="universities">
          <SelectInput optionText="name" />
        </ReferenceInput>
      </SimpleForm>
    </Create>
  );
};
