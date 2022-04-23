import * as React from "react";
import {
  Edit,
  SimpleForm,
  TextInput,
  ReferenceInput,
  SelectInput,
} from "react-admin";

export const DepartmentEdit = ({ permissions, ...props }) => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput source="id" />
        <ReferenceInput source="facultyId" reference="faculties">
          <SelectInput optionText="name" />
        </ReferenceInput>
        <ReferenceInput source="departmentCodeId" reference="department-codes">
          <SelectInput optionText="name" />
        </ReferenceInput>
      </SimpleForm>
    </Edit>
  );
};
