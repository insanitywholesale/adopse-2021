import styled from "@emotion/styled";
import { InputBase, TextField } from "@mui/material";
import React from "react";

const CssTextField = styled(TextField)({
  "& label.Mui-focused": {
    color: "#6E7198",
    borderRadius: "12px",
  },
  "& .MuiInputBase-input": {
    fontSize: "18px",
    height: "20px",
  },
  "& .MuiInput-underline:after": {
    borderBottomColor: "#6E7198",
    color: "#6E7198",
  },
  "& .MuiOutlinedInput-root": {
    padding: "0px 8px !important",
    "& fieldset": {
      borderColor: "#6E7198",
      borderWidth: 2,
      borderRadius: "12px !important",
    },
    "&:hover fieldset": {
      borderColor: "#6E7198",
    },
    "&.Mui-focused fieldset": {
      borderColor: "#6E7198",
    },
  },
});

const BootstrapInput = styled(InputBase)(({ theme }) => ({
  "label + &": {},
  "& .MuiInputBase-input": {
    borderRadius: 12,
    position: "relative",
    border: "2px solid #6E7198",
    fontSize: 16,
    background: "",
    padding: "10px 12px",
  },
  ".Mui-disabled":{
    cursor:'not-allowed'
  }
}));
function CommonInput({ name, label, disabledInput, variant,handleChange, type, ...rest }) {
  return (
    <BootstrapInput
      name={name}
      label={label}
      type={type}
      disabled={disabledInput}
      variant={variant}
      onChange={handleChange}
      {...rest}
    />
  );
}

export default CommonInput;
