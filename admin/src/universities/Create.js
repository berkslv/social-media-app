import * as React from "react";
import { Create, SimpleForm, TextInput, SelectInput } from "react-admin";
import { cities } from "../constants/cities";

export const UniversityCreate = ({ permissions, ...props }) => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput source="name" />
        <SelectInput source="city" choices={cities} />
        <TextInput source="foundationYear" />
      </SimpleForm>
    </Create>
  );
};
