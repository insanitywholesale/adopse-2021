import { Button } from "@mui/material";
import React from "react";
import CommonInput from "../../Component/Common/MaterialInputs/CommonInput";
import PrimaryTab from "../../Component/HomePage/PrimaryTab";
import Layout from "../../Layout";
import "./_homepage.scss";
function Homepage() {
  return (
    <Layout>
      <section className="login-home-wrapper  mt-180 pb-128">
        <div className="d-flex Info-Section justify-content-center row">
          <div className="user-info col-4 ">
            <h4 className="text-center">User Info:</h4>
            <p className="mt-17">Username:</p>
            <p className="mt-17">First Name:</p>
            <p className="mt-17">Last Name:</p>
            <p className="mt-17">Email:</p>
          </div>
          <div className="attribute-section col-8">
            <h4 className="text-center">Qualifications & Attributes</h4>
          </div>
        </div>
        <div className="join-input d-flex justify-content-center align-items-end mt-50">
          <div>
            <p>Join Evaluation</p>
            <CommonInput
              name="evaluationkey"
              placeholder="join evaluation key"
            />
          </div>
          <Button className="secondary-button ml-2 ">Join</Button>
        </div>
        <h3 className="Library-title">Evaluation Library</h3>
        {/* 
        {
            /---- Primary Tab and Table ------/
        }
        */}
        <PrimaryTab />
      </section>
    </Layout>
  );
}

export default Homepage;
