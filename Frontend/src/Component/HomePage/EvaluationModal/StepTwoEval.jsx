import React from "react";
import { Button, Dialog, DialogActions, DialogTitle } from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";
import "./_Modals.scss";
import CommonFormInputs from "../../Common/MaterialInputs/CommonTextArea";

export const StepTwoEval = ({ openPopUp, closePopUp }) => {
  const [open, setOpen] = React.useState(false);

  const handleClickOpen = () => {
    setOpen(true);
    // closePopUp()
  };

  const handleClose = () => {
    setOpen(false);
    closePopUp();
  };
  const handleOnlyCloce = () => {
    setOpen(false);
  };

  return (
    <div>
      {/* <Button className="action-btns" >
        Activate
      </Button> */}

      <Button onClick={handleClickOpen} className="dialog-btns-active">
        Next Step
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
          <div className="inputs-sections">
            <select name="category" className="evaluation-category" id="cars">
              <option value="option1">Select Evaluation Category</option>
            </select>

            <CommonFormInputs
              rows={5}
              multiline
              fullWidth
              className="TextArea-input"
              placeholder="Evaluation Description"
            />

            <p className="f-16 mt-4">Add tags, seperate with commas</p>

            <CommonFormInputs
              rows={5}
              multiline
              fullWidth
              className="TextArea-input"
            />

            <div className="d-flex align-items-center mt-3">
              <p className="f-16 mr-2">Auto Show Results</p>
              <label className="switch">
                <input type="checkbox" />
                <span className="slider round"></span>
              </label>
            </div>
            <div className="d-flex align-items-center mt-3">
              <p className="f-16 mr-2">
                Send results to my email uppon deactivation
              </p>
              <label className="switch">
                <input type="checkbox" />
                <span className="slider round"></span>
              </label>
            </div>
            <div className="d-flex align-items-center mt-3">
              <p className="f-16 mr-2">Acivate Evaluation Now</p>
              <label className="switch">
                <input type="checkbox" />
                <span className="slider round"></span>
              </label>
            </div>
          </div>

          <Button className="secondary-button p-4 mt-5">
            Randomise Question
          </Button>
        </div>

        <DialogActions
          className="justify-content-between m-auto mt-50 pb-4"
          style={{ width: "800px" }}
        >
          <Button onClick={handleClose} className="dialog-btns-primary">
            Cancel
          </Button>
          <Button onClick={handleOnlyCloce} className="dialog-btns-secondary">
            Back
          </Button>
          <Button onClick={handleClose} className="dialog-btns-active">
            Save Evaluation
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};
