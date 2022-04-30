import { Button } from "@mui/material";
import React from "react";

function CommonButton({ text, ...rest }) {
  return (
    <Button type="submit" className="primary-button" {...rest}>
      {text}
    </Button>
  );
}

export default CommonButton;
