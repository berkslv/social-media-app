import * as React from "react";
import {
  Create,
  SimpleForm,
  ReferenceInput,
  SelectInput,
} from "react-admin";

export const DepartmentCreate = ({ permissions, ...props }) => {
  return (
    <Create {...props}>
      <SimpleForm>
        <ReferenceInput source="facultyId" reference="faculties">
          <SelectInput optionText="name" />
        </ReferenceInput>
        <ReferenceInput source="departmentCodeId" reference="department-codes">
          <SelectInput optionText="name" />
        </ReferenceInput>
      </SimpleForm>
    </Create>
  );
};
