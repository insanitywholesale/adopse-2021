import React, { useState } from "react";
import { Button, Dialog, DialogActions, DialogTitle } from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";
import "./_Modals.scss";
import CommonFormInputs from "../../Common/MaterialInputs/CommonTextArea";
import { StepTwoEval } from "./StepTwoEval";
import ClearIcon from "@mui/icons-material/Clear";
import AllQuestions from "./AllQuestions";

export const StepOneEval = () => {
  // const [FirstQ,setFirstQ] = useState(true)
  const [QArr, setQArr] = useState([]);
  const [counter, setCounter] = useState(0);
  const [open, setOpen] = React.useState(false);
  const [ChoiceArr, setChoiceArr] = useState([]);
  const [countChoice, setcountChoice] = useState(0);
  const [ShowQuestion, setShowQuestion] = useState(false);

  const handleAllQuestion = () => {
    if (QArr.length < 5) {
      setCounter(counter + 1);

      setQArr([...QArr, counter]);
    }
  };

  const handleDeleteQuestion = (item) => {
    console.log(item);

    let newData = QArr.filter((value) => value != item);
    console.log(newData);
    setQArr(newData);
  };

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div>
      <Button className="secondary-button p-4 " onClick={handleClickOpen}>
        Create Evaluation
      </Button>
      <Dialog
        open={open}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        className="steptwo-dialog"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title" className=""></DialogTitle>

        <div className="main-content d-flex justify-content-center flex-column align-items-center">
          <input
            type="text"
            className="evaluation-name"
            placeholder="Evaluation Name"
          />

          {
            QArr.length > 0 &&
            <div className="body-wrapper">
              {QArr.map((item) => (
                <AllQuestions
                  dataItem={item}
                  hanldeDelete={handleDeleteQuestion}
                />
              ))}
            </div>
          }

          {/* <AllQuestions /> */}

          <div style={{ width: "600px" }}>
            <Button
              className="secondary-button mt-3"
              onClick={handleAllQuestion}
            >
              Add Questions
            </Button>
          </div>
        </div>

        <DialogActions
          className="justify-content-around m-auto mt-50 pb-4"
          style={{ width: "800px", columngap: "40px" }}
        >
          <Button onClick={handleClose} className="dialog-btns-primary ">
            Cancel
          </Button>

          {/* <Button onClick={handleClose} className="dialog-btns-active">
            Next Step
          </Button> */}
          <StepTwoEval closePopUp={handleClose} openPopUp={handleClickOpen} />
        </DialogActions>
      </Dialog>
    </div>
  );
};
