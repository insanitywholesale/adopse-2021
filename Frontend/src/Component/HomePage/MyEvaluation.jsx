import React from "react";
import { styled } from "@mui/material/styles";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import { Button, Pagination } from "@mui/material";
import PaginationItem from "@mui/material/PaginationItem";
import ArrowDropDownIcon from "@mui/icons-material/ArrowDropDown";
import { ActivateModal } from "./ActivateModal";
import { DeleteModal } from "./DeleteModal";

function MyEvaluation() {
    const StyledTableCell = styled(TableCell)(({ theme }) => ({
        [`&.${tableCellClasses.head}`]: {
          backgroundColor: "#999999;",
          color: "#000000",
          fontSize: 18,
          border: "1px solid",
        },
        [`&.${tableCellClasses.body}`]: {
          border: "1px solid",
        },
      }));
    
      const rows = [
        createData("Evaluation 1", "Lorem Ipsum", "Lorem Ipsum"),
        createData("Evaluation 2", "Lorem Ipsum", "Lorem Ipsum"),
        createData("Evaluation 3", "Lorem Ipsum", "Lorem Ipsum"),
      ];
    
      function createData(name, type, categories) {
        return { name, type, categories };
      }
    
      const StyledTableRow = styled(TableRow)(({ theme }) => ({
        backgroundColor: "#C4C4C4;",
        textAlign: "center",
        fontsize: 25,
        border: "1px solid",
      }));
    
  return (
    <>
      <Table className="mt-1">
        <TableHead>
          <TableRow>
            <StyledTableCell width={300}>
              <div className="d-flex align-items-center">
                Name
                <ArrowDropDownIcon sx={{ fontSize: 40, marginLeft: "-5px" }} />
              </div>
            </StyledTableCell>
            <StyledTableCell align="left">
              <div className="d-flex align-items-center">
                Type
                <ArrowDropDownIcon sx={{ fontSize: 40, marginLeft: "-5px" }} />
              </div>
            </StyledTableCell>
            <StyledTableCell align="left">
              <div className="d-flex align-items-center">
                Categories
                <ArrowDropDownIcon sx={{ fontSize: 40, marginLeft: "-5px" }} />
              </div>
            </StyledTableCell>
            <StyledTableCell align="center">Actions</StyledTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row) => (
            <StyledTableRow key={row.name}>
              <StyledTableCell component="th" scope="row">
                {row.name}
              </StyledTableCell>
              <StyledTableCell component="th" scope="row"></StyledTableCell>
              <StyledTableCell component="th" scope="row"></StyledTableCell>
              <StyledTableCell align="center" component="th" scope="row">
                <div className="d-flex justify-content-center">
                  <ActivateModal />
                  <Button className="action-btns">Edit</Button>
                  <DeleteModal />
                </div>
              </StyledTableCell>
            </StyledTableRow>
          ))}
        </TableBody>
      </Table>
      <Pagination
        count={5}
        className="mt-30"
        variant="outlined"
        shape="rounded"
      />
    </>
  );
}

export default MyEvaluation;
