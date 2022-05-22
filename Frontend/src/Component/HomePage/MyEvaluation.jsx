import React, { useState, useEffect } from "react";
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

  const [data, setData] = useState([]);

  function handlePageChange(event, page) {
    let link = `https://adopseback.inherently.xyz/api/evaluation/`;
    let z = page * 3;
    const evals = [];
    fetch(link + z)
      .then((response) => response.json())
      .then((evaluation) => {
        evals.push(evaluation);
      });
    z += 1;
    fetch(link + z)
      .then((response) => response.json())
      .then((evaluation) => {
        evals.push(evaluation);
      });
    z += 1;
    fetch(link + z)
      .then((response) => response.json())
      .then((evaluation) => {
        evals.push(evaluation);
        setData([...evals]);
      });
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
                No. Of Questions
                <ArrowDropDownIcon sx={{ fontSize: 40, marginLeft: "-5px" }} />
              </div>
            </StyledTableCell>
            <StyledTableCell align="center">Actions</StyledTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {data.map((row) => (
            <StyledTableRow key={row.id}>
              <StyledTableCell component="th" scope="row">
                {row.title}
              </StyledTableCell>
              <StyledTableCell component="th" scope="row">
                {row.isGraded ? "graded" : "not graded"}
              </StyledTableCell>
              <StyledTableCell component="th" scope="row">
                {row.questions.openQuestions.length +
                  row.questions.multipleChoiceQuestions.length}
              </StyledTableCell>
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
      <div>data length {data.length}</div>
      <Pagination
        count={5}
        className="mt-30"
        variant="outlined"
        shape="rounded"
        onChange={handlePageChange}
      />
    </>
  );
}

export default MyEvaluation;
