import { Button } from "@mui/material";
import React from "react";
import EvaluationHistory from "./EvaluationHistory";
import { StepOneEval } from "./EvaluationModal/StepOneEval";
import { StepTwoEval } from "./EvaluationModal/StepTwoEval";
import MyEvaluation from "./MyEvaluation";

function PrimaryTab() {
  const [evaluation, setEvaluation] = React.useState(true);
  const [evaluationHistory, setEvaluationHistory] = React.useState(false);
  const [openTab, setOpenTab] = React.useState("one");

  const showEvaluation = () => {
    setEvaluation(true);
    setEvaluationHistory(false);
  };
  const showHistory = () => {
    setEvaluationHistory(true);
    setEvaluation(false);
  };
  return (
    <div className="primary-tab-wrapper mt-50">
      <div className="tabs-wrapper d-flex align-items-center justify-content-between">
        <div className="tab-links">
          <Button
            className={`tabs-button ${evaluation && "active"} `}
            onClick={showEvaluation}
          >
            {" "}
            My Evaluation{" "}
          </Button>
          <Button
            className={`tabs-button ${evaluationHistory && "active"}`}
            onClick={showHistory}
          >
            Evaluation History{" "}
          </Button>
        </div>
        <StepOneEval />
      </div>
      {evaluation && <MyEvaluation />}
      {evaluationHistory && <EvaluationHistory />}
    </div>
  );
}

export default PrimaryTab;
