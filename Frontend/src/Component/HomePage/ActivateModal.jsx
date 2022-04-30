import React from "react";
import {
  Button,
  Dialog,
  DialogActions,
  DialogTitle,
  Modal,
} from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";

export const ActivateModal = () => {
  const [open, setOpen] = React.useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div>
      <Button className="action-btns" onClick={handleClickOpen}>
        Activate
      </Button>
      <Dialog
        open={open}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
        sx={{
          "& .MuiDialog-container": {
            "& .MuiPaper-root": {
              width: "100%",
              maxWidth: "340px", // Set your width here
            },
          },
        }}

        //   sx={{width:'300px'}}
      >
        <DialogTitle
          id="alert-dialog-title"
        //   style={{ borderBottom: "2px solid #efefef" }}
          className='bottomGrey-border'
        >
          <div className="d-flex justify-content-between  align-items-center">
            Evaluation Activated
            <CloseIcon onClick={handleClose} style={{cursor:'pointer'}} />
          </div>
        </DialogTitle>
        <div
          className="d-flex justify-content-center p-16 bottomGrey-border"
          
        >
          <p>Evaluation key</p>
        </div>
        <DialogActions className="justify-content-center">
          <Button onClick={handleClose} className="dialog-btns-primary">
            Copy Key
          </Button>
          <Button onClick={handleClose} className="dialog-btns-secondary">
            Done
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};
