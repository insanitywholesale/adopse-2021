import React, { useState } from "react";
import { Button, Dialog, DialogActions, DialogTitle } from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";
import "./_Modals.scss";
import CommonFormInputs from "../../Common/MaterialInputs/CommonTextArea";
import { StepTwoEval } from "./StepTwoEval";
import ClearIcon from "@mui/icons-material/Clear";
import AllQuestions from "./AllQuestions";

export const ShowDetails = () => {
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
        Show Details
      </Button>
      <Dialog
        open={open}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        className="showDetail-dialog"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title" className=""></DialogTitle>

        <div className="main-content d-flex justify-content-center flex-column align-items-center">
          <div style={{ width: "600px" }}>
            <div className=" Info-Section justify-content-center row m-0">
              <div className="user-info col-4 ">
                <p className="mt-17">Participation Id:</p>
                <p className="mt-17">First Name:</p>
                <p className="mt-17">Last Name:</p>
                <p className="mt-17">Email:</p>
              </div>
              <div className="attribute-section col-8"></div>
            </div>
            <div className="d-flex justify-content-center mt-3">
              <input
                type="text"
                className="evaluation-name"
                placeholder="Evaluation Name"
              />
            </div>
            <CommonFormInputs
              fullWidth
              className="mt-3 TextArea-input"
              placeholder="Question Type"
            />
            <CommonFormInputs
              rows={5}
              multiline
              fullWidth
              className="TextArea-input"
              placeholder="Evaluation Description"
            />
            <CommonFormInputs
              className="TextArea-input "
              placeholder="Correct Choice"
            />
            <CommonFormInputs
              className="TextArea-input mx-2"
              placeholder="Correct Choice"
            />
            <CommonFormInputs
              className="TextArea-input"
              placeholder="Correct Choice"
            />

            <CommonFormInputs
              fullWidth
              className="TextArea-input mt-3"
              placeholder="Selected Choice "
            />
            <CommonFormInputs
              fullWidth
              multiline
              rows={5}
              className="TextArea-input mt-3"
              placeholder="Answer "
            />
          </div>
        </div>

        <DialogActions
          className="justify-content-around m-auto mt-50 pb-4"
          style={{ width: "800px", columngap: "40px" }}
        >
          <Button onClick={handleClose} className="dialog-btns-primary ">
            Cancel
          </Button>

          <Button onClick={handleClose} className="dialog-btns-active">
            Close
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};
