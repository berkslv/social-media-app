import * as React from "react";
import { Admin, Resource } from "react-admin";
import { UserList, UserEdit, UserCreate } from "./users";
import {
  UniversityList,
  UniversityEdit,
  UniversityCreate,
} from "./universities";
import { FacultyList, FacultyEdit, FacultyCreate } from "./faculties";
import {
  DepartmentList,
  DepartmentEdit,
  DepartmentCreate,
} from "./departments";
import {
  DepartmentCodeList,
  DepartmentCodeEdit,
  DepartmentCodeCreate,
} from "./departmentCodes";
import { TagList, TagEdit, TagCreate } from "./tags";
import { PostList, PostEdit, PostCreate } from "./posts";
import { CommentList, CommentEdit, CommentCreate } from "./comments";

import Dashboard from "./Dashboard";
import authProvider from "./authProvider";
import dataProvider from "./dataProvider";

import { createTheme } from "@material-ui/core/styles";
import SchoolIcon from "@material-ui/icons/School";
import BookIcon from "@material-ui/icons/Book";
import PersonIcon from "@material-ui/icons/Person";

const theme = createTheme({
  palette: {
    type: "dark",
    primary: {
      main: "#fb923c",
    },
    secondary: {
      main: "#4338ca",
    },
  },
});

const App = () => {
  return (
    <Admin
      theme={theme}
      title={"College Hub - Admin"}
      dashboard={Dashboard}
      authProvider={authProvider}
      dataProvider={dataProvider}
    >
      <Resource
        name="users"
        list={UserList}
        edit={UserEdit}
        create={UserCreate}
        icon={PersonIcon}
      />
      <Resource
        name="universities"
        list={UniversityList}
        edit={UniversityEdit}
        create={UniversityCreate}
        icon={SchoolIcon}
      />
      <Resource
        name="faculties"
        list={FacultyList}
        edit={FacultyEdit}
        create={FacultyCreate}
        icon={SchoolIcon}
      />
      <Resource
        name="departments"
        list={DepartmentList}
        edit={DepartmentEdit}
        create={DepartmentCreate}
        icon={SchoolIcon}
      />
      <Resource
        name="department-codes"
        list={DepartmentCodeList}
        edit={DepartmentCodeEdit}
        create={DepartmentCodeCreate}
        icon={SchoolIcon}
      />
      <Resource
        name="tags"
        list={TagList}
        edit={TagEdit}
        create={TagCreate}
        icon={BookIcon}
      />
      <Resource
        name="posts"
        list={PostList}
        edit={PostEdit}
        create={PostCreate}
        icon={BookIcon}
      />
      <Resource
        name="comments"
        list={CommentList}
        edit={CommentEdit}
        create={CommentCreate}
        icon={BookIcon}
      />
    </Admin>
  );
};

export default App;
