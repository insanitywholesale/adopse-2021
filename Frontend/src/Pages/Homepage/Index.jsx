import React,{useState} from "react";
import CommonButton from "../../Component/Common/MaterialInputs/CommonButton";
import CommonInput from "../../Component/Common/MaterialInputs/CommonInput";
import Layout from "../../Layout";
import "./_home.scss";

const Index = ()=> {
  const [EmailError, setEmailError] = useState(false);
  const handleSubmit = (e)=>{
    
    e.preventDefault()
    if (e.target.email.value == "") {
      setEmailError(true);
    }
  }
  const handleEmailError = (e) => {
    
    if (e.target.value != "") {
      setEmailError(false);
    } else {
      setEmailError(true);
    }
  };
  return (
    <Layout background="bg-color-SuperSilver">
      <div className="home-wrapper mt-180 ">
        <div className="primary-card">
          <h1 className="f-30 fw-400">Title</h1>
          <p className="f-22 color-basalt-grey mt-17">Description</p>
          <div className="d-flex mt-30 email-Form">
            <form onSubmit={handleSubmit}> 
              <CommonInput
                style={{ width: "392px" }}
                type="email"
                label="Email"
                name="email"
                className='mr-2'
                handleChange={handleEmailError}
                />
              
              <CommonButton text="Register"  />
              
            </form>
          </div>
          {EmailError && (
                  <p
                    className="text-danger text-left mt-1"
                    style={{ width: "375px" }}
                  >
                    
                    Email is Required
                  </p>
                )}
        </div>

        <div className="row m-0 bg-color-dhusar-grey mt-180 pb-128">
          <div className="col-12">
            <div className="d-flex justify-content-center mt-50">
              {[1, 2, 3].map((card) => (
                <div className="feature-card">
                  <h4 className="f-30 fw-400">Feature {card}</h4>
                  <p className="color-bank-vault fw-400 mt-17">
                    Feature Description
                  </p>
                </div>
              ))}
            </div>
            <div className="d-flex justify-content-center ">
              {[4, 5, 6].map((card) => (
                <div className="feature-card">
                  <h4 className="f-30 fw-400">Feature {card}</h4>
                  <p className="color-bank-vault fw-400 mt-17">
                    Feature Description
                  </p>
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>
    </Layout>
  );
}

export default Index;
