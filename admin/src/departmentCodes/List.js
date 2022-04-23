import * as React from "react";
import { List, Datagrid, EditButton, TextField, SimpleList } from "react-admin";
import { useMediaQuery } from "@material-ui/core";
import Unauthorized from "../shared/Unauthorized";

export const DepartmentCodeList = ({ permissions, ...props }) => {
  
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
            tertiaryText={(record) => record.id}
          />
        ) : (
          <Datagrid>
            <TextField source="id" />
            <TextField source="name" />
            <EditButton />
          </Datagrid>
        )}
      </List>
    );
  } else {
    return <Unauthorized />;
  }
};
