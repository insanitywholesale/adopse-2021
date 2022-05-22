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

  const [data, setData] = useState([
    {
      id: 1,
      title: "Elksage",
      isGraded: false,
      questions: {
        id: 1,
        openQuestions: [
          {
            answer: null,
            id: 1,
            heading: "9",
            grade: 0,
            isGraded: false,
          },
          {
            answer: {
              contentFromEvaluee: "Dukepool",
              id: 1,
              isCorrectAnswer: false,
              grade: 0,
            },
            id: 2,
            heading: "Droplaser",
            grade: 8,
            isGraded: false,
          },
        ],
        multipleChoiceQuestions: [
          {
            hasCorrectAnswer: false,
            answers: [
              {
                content: "Ogresand",
                selectedByEvaluee: false,
                id: 1,
                isCorrectAnswer: false,
                grade: 1,
              },
              {
                content: "Cranelapis",
                selectedByEvaluee: false,
                id: 2,
                isCorrectAnswer: true,
                grade: 3,
              },
              {
                content: "Flamecherry",
                selectedByEvaluee: false,
                id: 3,
                isCorrectAnswer: false,
                grade: 4,
              },
            ],
            id: 1,
            heading: "Glassberyl",
            grade: 0,
            isGraded: false,
          },
          {
            hasCorrectAnswer: false,
            answers: [
              {
                content: "Friendfern",
                selectedByEvaluee: false,
                id: 4,
                isCorrectAnswer: true,
                grade: 2,
              },
              {
                content: "Wolfzest",
                selectedByEvaluee: false,
                id: 5,
                isCorrectAnswer: true,
                grade: 3,
              },
              {
                content: "Hairboom",
                selectedByEvaluee: false,
                id: 6,
                isCorrectAnswer: false,
                grade: 2,
              },
            ],
            id: 2,
            heading: "Goosecandle",
            grade: 9,
            isGraded: false,
          },
        ],
      },
    },
    {
      id: 2,
      title: "Heroniridescent",
      grade: 0,
      isGraded: false,
      questions: {
        id: 2,
        openQuestions: [
          {
            answer: null,
            id: 3,
            heading: "5",
            grade: 0,
            isGraded: true,
          },
          {
            answer: {
              contentFromEvaluee: "Faceiris",
              id: 2,
              isCorrectAnswer: false,
              grade: 0,
            },
            id: 4,
            heading: "Stalkerpickle",
            grade: 4,
            isGraded: true,
          },
        ],
        multipleChoiceQuestions: [
          {
            hasCorrectAnswer: false,
            answers: [
              {
                content: "Shakergeode",
                selectedByEvaluee: false,
                id: 7,
                isCorrectAnswer: false,
                grade: 1,
              },
              {
                content: "Dogribbon",
                selectedByEvaluee: false,
                id: 8,
                isCorrectAnswer: false,
                grade: 3,
              },
              {
                content: "Banecerulean",
                selectedByEvaluee: false,
                id: 9,
                isCorrectAnswer: true,
                grade: 2,
              },
            ],
            id: 3,
            heading: "Browsprout",
            grade: 0,
            isGraded: false,
          },
          {
            hasCorrectAnswer: false,
            answers: [
              {
                content: "Keeperlinen",
                selectedByEvaluee: true,
                id: 10,
                isCorrectAnswer: false,
                grade: 1,
              },
              {
                content: "Cloudplume",
                selectedByEvaluee: false,
                id: 11,
                isCorrectAnswer: false,
                grade: 2,
              },
              {
                content: "Ladystream",
                selectedByEvaluee: true,
                id: 12,
                isCorrectAnswer: false,
                grade: 2,
              },
            ],
            id: 4,
            heading: "Servantshell",
            grade: 5,
            isGraded: false,
          },
        ],
      },
    },
    {
      id: 4,
      title: "Parrotrose",
      grade: 0,
      isGraded: false,
      questions: {
        id: 4,
        openQuestions: [
          {
            answer: null,
            id: 7,
            heading: "7",
            grade: 0,
            isGraded: true,
          },
          {
            answer: {
              contentFromEvaluee: "Kickersteel",
              id: 4,
              isCorrectAnswer: false,
            },
            id: 8,
            heading: "Paladinmad",
            grade: 3,
            isGraded: true,
          },
        ],
        multipleChoiceQuestions: [
          {
            hasCorrectAnswer: false,
            answers: [
              {
                content: "Koalaclever",
                selectedByEvaluee: false,
                id: 19,
                isCorrectAnswer: false,
                grade: 1,
              },
              {
                content: "Fishcrack",
                selectedByEvaluee: false,
                id: 20,
                isCorrectAnswer: true,
                grade: 2,
              },
              {
                content: "Mothivory",
                selectedByEvaluee: false,
                id: 21,
                isCorrectAnswer: false,
                grade: 4,
              },
            ],
            id: 7,
            heading: "Piratecandy",
            grade: 0,
            isGraded: false,
          },
          {
            hasCorrectAnswer: true,
            answers: [
              {
                content: "Molechecker",
                selectedByEvaluee: false,
                id: 22,
                isCorrectAnswer: true,
                grade: 1,
              },
              {
                content: "Molered",
                selectedByEvaluee: true,
                id: 23,
                isCorrectAnswer: false,
                grade: 1,
              },
              {
                content: "Trackpool",
                selectedByEvaluee: true,
                id: 24,
                isCorrectAnswer: true,
                grade: 2,
              },
            ],
            id: 8,
            heading: "Shriekerjust",
            grade: 2,
            isGraded: false,
          },
        ],
      },
    },
  ]);

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
