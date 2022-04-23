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

export const UserList = ({ permissions, ...props }) => {
  const isSmall = useMediaQuery((theme) => theme.breakpoints.down("sm"));

  if (permissions === undefined) {
    return <Unauthorized />;
  }

  if (permissions.includes("Admin")) {
    return (
      <List {...props} perPage={10}>
        {isSmall ? (
          <SimpleList
            primaryText={(record) => record.email}
            secondaryText={(record) => record.role}
            tertiaryText={(record) => record.id}
          />
        ) : (
          <Datagrid>
            <TextField source="id" />
            <TextField source="name" />
            <TextField source="email" />
            <TextField source="username" />
            <TextField source="role" />
            <TextField source="status" />
            <ReferenceField source="universityId" reference="universities">
              <TextField source="name" />
            </ReferenceField>
            <ReferenceField source="facultyId" reference="faculties">
              <TextField source="name" />
            </ReferenceField>
            <ReferenceField source="departmentId" reference="departments">
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
