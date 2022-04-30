import styled from "@emotion/styled";
import { InputBase } from "@mui/material";
import React from "react";

const BootstrapInput = styled(InputBase)(({ theme }) => ({
  "label + &": {},
  "& .MuiInputBase-input": {
    borderRadius: 0,
    position: "relative",
    border: "none",
    fontSize: 16,
    background: "#EEEEEE",
    padding: "10px 12px",
  },
}));

function CommonFormInputs({placeholder,...rest}) {
  return (
    <BootstrapInput
      placeholder={placeholder}
      {...rest}
    />
  );
}

export default CommonFormInputs;
