import React, { useState } from "react";
import Layout from "../../Layout";
import "./_profile.scss";
import SettingsIcon from "@mui/icons-material/Settings";

import CommonFormInputs from "../../Component/Common/MaterialInputs/CommonTextArea";
import { Switch } from "@mui/material";
import CommonButton from "../../Component/Common/MaterialInputs/CommonButton";
import CommonInput from "../../Component/Common/MaterialInputs/CommonInput";

function Index() {
  const [IsEnabled, setIsEnabled] = useState(true);

  const enableInputs = (value) => {
    console.log(value.target.checked);
    setIsEnabled(!value.target.checked);
  };

  return (
    <Layout>
      <div className="profile-wrapper pb-128">
        <div className="primary-card">
          <h4 className="f-40 fw-400 d-flex justify-content-center align-items-center">
            Manage Profile <SettingsIcon sx={{ fontSize: 40 }} />{" "}
          </h4>

          <p className="f-22 fw-400 mt-17">Attributes & Qualifications</p>
          <CommonFormInputs
            rows={5}
            multiline
            fullWidth
            placeholder="You can list your attributes & qualifications here"
          />

          <div className="d-flex m-auto mt-50" style={{ width: "435px" }}>
            <h4 className="f-30  fw-400">Change Password</h4>
            <Switch onChange={enableInputs} />
          </div>
          <div className="secondary-card m-auto">
            <div>
              <p>Old Password</p>
              <CommonInput
                disabledInput={IsEnabled}
                style={{ width: "392px" }}
              />
            </div>
            <div>
              <p>New Password</p>
              <CommonInput
                disabledInput={IsEnabled}
                style={{ width: "392px" }}
              />
            </div>
            <div>
              <p>Confirm Password</p>
              <CommonInput
                disabledInput={IsEnabled}
                style={{ width: "392px" }}
              />
            </div>
          </div>
          <CommonButton text="Save Changes" />
        </div>
      </div>
    </Layout>
  );
}

export default Index;
