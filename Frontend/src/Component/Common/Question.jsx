{
  /* <div className={`main-body ${FirstQ && 'd-none'}`}>
<div className="inputs-sections d-flex justify-content-between">
  <select
    name="category"
    className="evaluation-category"
    onChange={hanldeChoice}
  >
    <option value="mcq">Multiple Choice</option>
    <option value="open">Open</option>
  </select>
  <button onClick={()=>setFirstQ(false)} className="remove-rounded-btn">-</button>
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
      <select name="category" className="choice-option ml-2 mr-2">
        <option value="choice-1">Correct Choice</option>
        <option value="choice-2">Choice 1</option>
      </select>

      <label className="enable mb-0 ">
        <input type="checkbox" className="required-input" />
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
            <input
              type="radio"
              name="choice"
              className="selector"
            />
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

    <Button className="choice-btn " onClick={hanldeInputChoice}>
      Add Choice
    </Button>
  </>
)}
<hr style={{ border: "1px solid #000000" }} />
</div> */
}
