import * as React from "react";
import {
  List,
  Datagrid,
  EditButton,
  TextField,
  ReferenceField,
  SimpleList,
} from "react-admin";
import { useMediaQuery } from "@material-ui/core";
import Unauthorized from "../shared/Unauthorized";

export const DepartmentList = ({ permissions, ...props }) => {
  const isSmall = useMediaQuery((theme) => theme.breakpoints.down("sm"));

  if (permissions === undefined) {
    return <Unauthorized />;
  }

  if (permissions.includes("Admin")) {
    return (
      <List {...props} perPage={10}>
        {isSmall ? (
          <SimpleList
            primaryText={(record) => record.name}
            secondaryText={
              <ReferenceField source="facultyId" reference="faculties">
                <TextField source="name" />
              </ReferenceField>
            }
            tertiaryText={(record) => record.id}
          />
        ) : (
          <Datagrid>
            <TextField source="id" />
            <TextField source="name" />
            <ReferenceField source="facultyId" reference="faculties">
              <TextField source="name" />
            </ReferenceField>
            <ReferenceField
              source="departmentCodeId"
              reference="department-codes"
            >
              <TextField source="name" />
            </ReferenceField>
            <EditButton />
          </Datagrid>
        )}
      </List>
    );
  } else {
    return <Unauthorized />;
  }
};
