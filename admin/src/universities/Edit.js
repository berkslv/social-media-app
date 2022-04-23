import * as React from "react";
import { Edit, SimpleForm, TextInput, SelectInput } from "react-admin";
import { cities } from "../constants/cities";

export const UniversityEdit = ({ permissions, ...props }) => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput source="id" />
        <TextInput source="name" />
        <SelectInput source="city" choices={cities} />
        <TextInput source="foundationYear" />
      </SimpleForm>
    </Edit>
  );
};
