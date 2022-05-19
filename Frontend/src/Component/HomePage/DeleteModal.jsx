import React from "react";
import {
  Button,
  Dialog,
  DialogActions,
  DialogTitle,
  Modal,
} from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";

export const DeleteModal = () => {
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
        Delete
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
        <DialogTitle id="alert-dialog-title" className="bottomGrey-border">
          <div className="d-flex justify-content-between  align-items-center">
            Delete Activated
            <CloseIcon onClick={handleClose} style={{ cursor: "pointer" }} />
          </div>
        </DialogTitle>
        <div className="p-4 bottomGrey-border">
          <p>Are you sure you want to delete this evaluation?</p>
        </div>
        <DialogActions className="justify-content-center">
          <Button onClick={handleClose} className="dialog-btns-secondary">
            Cancel
          </Button>
          <Button onClick={handleClose} className="dialog-btns-primary">
            Delete
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};
