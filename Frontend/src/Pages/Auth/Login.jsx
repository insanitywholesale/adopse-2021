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
import { useStore } from "../../Store/store";


function Login() {
  const [EmailError, setEmailError] = useState(false);
  const [PasswordError, setPasswordError] = useState(false);
  const [RememberMe, setRememberMe] = useState(false);
  const setLogedInState =  useStore(state=>state.setLogedIn)
  const login =  useStore(state=>state.logedIn)
  console.log(login,'ola state ')
  const handleSubmit = (values) => {
    values.preventDefault();
    
    if (values.target.email.value == "") {
      setEmailError(true);
    }
    if (values.target.password.value == "") {
      setPasswordError(true);
    }
    if (!values.target.remember.checked) {
      setRememberMe(true);
    }
    
    else {
      setLogedInState()
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
  const handleCheckbox = (e) => {
    
    if (e.target.checked) {
      setRememberMe(false);
    } else {
      setRememberMe(true);
    }
  };
  return (
    <Layout>
      <section className="login-wrapper mt-180 pb-128">
        <div className="row m-0">
          <div className="col-12 text-center">
            <form onSubmit={handleSubmit}>
              <div className=" primary-card">
                <h4 className="f-50 ">Login</h4>
                <div className="d-flex flex-column  align-items-center input-sections mt-75">
                  <CommonInput
                    name="email"
                    type="email"
                    style={{ width: "392px" }}
                    placeholder="Email"
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
                    name="password"
                    type="password"
                    placeholder="Password"
                    handleChange={handlePasswordError}
                    style={{ width: "392px", marginTop: "30px" }}
                  />
                  {PasswordError && (
                    <p
                      className="text-danger text-left mt-1"
                      style={{ width: "375px" }}
                    >
                      {" "}
                      Password is Required{" "}
                    </p>
                  )}

                  <div className="d-flex align-items-center mt-30">
                    <Checkbox name="remember" onChange={handleCheckbox} />
                    <p className="f-20 fw-300">Remember me</p>
                  </div>
                    {RememberMe && (
                      <p
                        className="text-danger text-left mb-3"
                        
                      >
                        Field is Required
                      </p>
                    )}

                  <CommonButton type="submit" text="Login" />
                  <p className="mt-30 color-splishSplash f-20 fw-300">
                    I forgot my password
                  </p>
                </div>
              </div>
            </form>
          </div>
        </div>
      </section>
    </Layout>
  );
}

export default Login;
