import {
  Button,
  Checkbox,
  CircularProgress,
  FormControlLabel,
  TextField,
} from "@mui/material";
import Layout from "../../Layout/index";
import React, { useState } from "react";
import "./_auth.scss";
import CommonInput from "../../Component/Common/MaterialInputs/CommonInput";
import styled from "@emotion/styled";
import CommonButton from "../../Component/Common/MaterialInputs/CommonButton";

function Register() {
  const [FNameError, setFNameError] = useState(false);
  const [LNameError, setLNameError] = useState(false);
  const [EmailError, setEmailError] = useState(false);
  const [PasswordError, setPasswordError] = useState(false);
  const [CPasswordError, setCPasswordError] = useState(false);
  const [Condition, setCondition] = useState(false);

  const handleSubmit = (values) => {
    values.preventDefault();
    if (values.target.firstName.value == "") {
      setFNameError(true);
    }
    if (values.target.firstName.value == "") {
      setLNameError(true);
    }
    if (values.target.email.value == "") {
      setEmailError(true);
    }
    if (values.target.Password.value == "") {
      setPasswordError(true);
    }
    if (values.target.C_Password.value == "") {
      setCPasswordError(true);
    }
    if (!values.target.agree.checked) {
      setCondition(true);
    }
  };

  const handleNameError = (e) => {
    if (e.target.value != "") {
      setFNameError(false);
    } else {
      setFNameError(true);
    }
  };
  const handleLNameError = (e) => {
    if (e.target.value != "") {
      setLNameError(false);
    } else {
      setLNameError(true);
    }
  };
  const handleEmailError = (e) => {
    if (e.target.value != "") {
      setEmailError(false);
    } else {
      setEmailError(true);
    }
  };
  const handlePasswordError = (e) => {
    if (e.target.value != "") {
      setPasswordError(false);
    } else {
      setPasswordError(true);
    }
  };
  const handleConfirmPassword = (e) => {
    if (e.target.value != "") {
      setCPasswordError(false);
    } else {
      setCPasswordError(true);
    }
  };
  const handleCheckbox = (e) => {
    
    if (e.target.checked) {
      setCondition(false);
    } else {
      setCondition(true);
    }
  };
  return (
    <Layout>
      <section className="login-wrapper mt-180 pb-128">
        <div className="row m-0">
          <div className="col-12 text-center">
            <form onSubmit={handleSubmit}>
              <div className=" primary-card">
                <h4 className="f-50 ">Regsiter</h4>
                <div className="d-flex flex-column  align-items-center input-sections mt-75">
                  <CommonInput
                    name="firstName"
                    type="text"
                    handleChange={handleNameError}
                    placeholder="First Name"
                    style={{ width: "392px" }}
                  />
                  {FNameError && (
                    <p
                      className="text-danger text-left mt-1"
                      style={{ width: "375px" }}
                    >
                      First Name is Required
                    </p>
                  )}
                  <CommonInput
                    name="lastName"
                    type="text"
                    handleChange={handleLNameError}
                    placeholder="Last Name"
                    style={{ width: "392px", marginTop: "30px" }}
                  />
                  {LNameError && (
                    <p
                      className="text-danger text-left mt-1"
                      style={{ width: "375px" }}
                    >
                      Last Name is Required
                    </p>
                  )}
                  <CommonInput
                    name="email"
                    type="email"
                    placeholder="Email Address"
                    style={{ width: "392px", marginTop: "30px" }}
                    handleChange={handleEmailError}
                  />
                  {EmailError && (
                    <p
                      className="text-danger text-left mt-1"
                      style={{ width: "375px" }}
                    >
                      Email is Required
                    </p>
                  )}
                  <CommonInput
                    name="Password"
                    type="text"
                    placeholder="Password"
                    handleChange={handlePasswordError}
                    style={{ width: "392px", marginTop: "30px" }}
                  />
                  {PasswordError && (
                    <p
                      className="text-danger text-left mt-1"
                      style={{ width: "375px" }}
                    >
                      Password is Required
                    </p>
                  )}
                  <CommonInput
                    name="C_Password"
                    type="text"
                    handleChange={handleConfirmPassword}
                    placeholder="Confirm Password"
                    style={{ width: "392px", marginTop: "30px" }}
                  />
                  {CPasswordError && (
                    <p
                      className="text-danger text-left mt-1"
                      style={{ width: "375px" }}
                    >
                      Confirm Password is Required
                    </p>
                  )}

                  <div className="d-flex align-items-center mt-30">
                    <Checkbox name="agree" onChange={handleCheckbox} /> 
                    <p className="f-20 fw-300">
                      I agree with the terms & conditions
                    </p>
                  </div>
                  {Condition && (
                    <p className="text-danger text-left  mb-3">
                      Field is Required
                    </p>
                  )}

                  <CommonButton type="submit" text=" Register" />
                </div>
              </div>
            </form>
          </div>
        </div>
      </section>
    </Layout>
  );
}

export default Register;
