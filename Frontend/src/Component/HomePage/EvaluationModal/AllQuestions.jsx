import { Button } from "@mui/material";
import React, { useState } from "react";
import CommonFormInputs from "../../Common/MaterialInputs/CommonTextArea";
import ClearIcon from "@mui/icons-material/Clear";

function AllQuestions({dataItem,hanldeDelete}) {


    const [ChoiceArr, setChoiceArr] = useState([]);
    const [countChoice, setcountChoice] = useState(0);
    const [ShowQuestion, setShowQuestion] = useState(false);
    const [enableChoice,setEnableChoice] = useState(true);
  const hanldeChoice = (e) => {
    console.log(e.target.value, ":: :: hello");
    switch (e.target.value) {
      case "open":
        return setShowQuestion(true);
      case "mcq":
        return setShowQuestion(false);
      default:
        return;
    }
  };

  const hanldeInputChoice = () => {
    if (ChoiceArr.length < 3) {
      setcountChoice(countChoice + 1);

      setChoiceArr([...ChoiceArr, countChoice]);
    }
  };
  const deleteChoiceOpt = (key) => {
    let returnItem = ChoiceArr.filter((item) => item != key);
    console.log(returnItem);
    setChoiceArr(returnItem);
  };
  const handleEnableChoice = ()=>{
      console.log('object');
      setEnableChoice(!enableChoice)
  }

  return (
    <div className="main-body">
      <div className="inputs-sections d-flex justify-content-between">
        <select
          name="category"
          className="evaluation-category"
          onChange={hanldeChoice}
        >
          <option value="mcq">Multiple Choice</option>
          <option value="open">Open</option>
        </select>
        <button className="remove-rounded-btn"  onClick={()=>hanldeDelete(dataItem)}>-</button>
      </div>
      {ShowQuestion ? (
        <>
          <CommonFormInputs
            rows={5}
            multiline
            fullWidth
            className="TextArea-input"
            placeholder="Question"
          />

          <p className="f-16 mt-4">Indicatory Answer (Optional):</p>

          <CommonFormInputs
            rows={5}
            multiline
            fullWidth
            className="TextArea-input"
          />
        </>
      ) : (
        <>
          <CommonFormInputs
            rows={5}
            multiline
            fullWidth
            className="TextArea-input"
            placeholder="Question"
          />
          <div className="d-flex  align-items-center ">
            <p className="f-20">Answer:</p>
            <select name="category"  className="choice-option ml-2 mr-2">
              <option >Correct Choice</option>
              <option value="choice-1">Choice 1</option>
              
              {
                ChoiceArr.map(item => (
                  <option value="choice-2">Choice {item+2}</option>
                ))
              }
            </select>

            <label className="enable mb-0 ">
              <input type="checkbox"  onClick={handleEnableChoice} className="required-input" />
              <span className="slider round"></span>
            </label>
          </div>

          <div className="choices-inputs  d-flex flex-wrap ">
            <div className="required-choice  d-flex align-items-center ">
              <input type="radio" name="choice" className="selector" />
              <input
                type="text"
                className="input-field"
                placeholder="Choice 1"
              />
            </div>

            {ChoiceArr.map((item) => (
              <>
                <div
                  key={item}
                  className="required-choice  d-flex align-items-center "
                >
                  <input type="radio" name="choice" className="selector" />
                  <input
                    type="text"
                    className="input-field"
                    placeholder={`Choice ${item + 2}`}
                  />
                  <ClearIcon
                    className="close-icon"
                    onClick={() => deleteChoiceOpt(item)}
                  />
                </div>
              </>
            ))}
          </div>
            {
                enableChoice ?  <button className="choice-btn " onClick={hanldeInputChoice}  >
                Add Choice
              </button> :
               <button className="choice-btn " style={{cursor:'not-allowed'}}  >
               Add Choice
             </button>
            }
         
        </>
      )}
      <hr style={{ border: "1px solid #000000" }} />
    </div>
  );
}

export default AllQuestions;
