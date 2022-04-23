import React from "react";
import { Card, CardContent, CardHeader } from "@material-ui/core";

const Unauthorized = () => {
  return (
    <Card>
      <CardHeader title="Unauthorized request" />
      <CardContent>
        You do not have the necessary privileges to access this resource.
      </CardContent>
    </Card>
  );
};

export default Unauthorized;
