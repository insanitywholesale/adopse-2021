import { g, h, x } from "./xeact.js";

(async () => {
	const baseURL = "http://localhost:5000/api";
	const resp = await fetch(baseURL+"/q");
	console.log("resp:", resp);
	const data = await resp.json();
	console.log("data:", data);

	let questions = g("question-root");
	x(questions);

	const oqs = data.openQuestions;
	const mcqs = data.multipleChoiceQuestions;

	questions.append(h("h1", {innerText: "Questions"}))

	questions.append(h("h2", {className: "open-header", innerText: "Open Questions"}))

	questions.append(...Object.entries(oqs).map(b => 
		h("div", {className: `question-${b[0]}`}, [
			h("h3", {className: "oq-header", innerText: "Question"}),
			h("span", {className: "oq-id", innerText: `Id: ${b[1].id}`}),
			h("br", {}),
			h("span", {className: "oq-heading", innerText: `Heading: ${b[1].heading}`}),
			h("br", {}),
			h("h3", {className: "oq-header", innerText: "Answer"}),
			h("div", {className: `o-qs`}, [
				h("span", {className: "oq-id", innerText: `Id: ${b[1].answer.id}`}),
				h("br", {}),
				h("span", {className: "oq-heading", innerText: `Heading: ${b[1].answer.contentFromEvaluee}`}),
				h("br", {}),
			]),
		]),
	))

	questions.append(h("h2", {className: "multiple-choice-header", innerText: "Multiple Choice Questions"}))

	questions.append(...Object.entries(mcqs).map(b => 
		h("div", {className: `mcq-${b[0]}`}, [
			h("h3", {className: "mcq-header", innerText: "Question"}),
			h("span", {className: "mcq-id", innerText: `Id: ${b[1].id}`}),
			h("br", {}),
			h("span", {className: "mcq-heading", innerText: `Heading: ${b[1].heading}`}),
			h("br", {}),
			h("h3", {className: "mcqa-header", innerText: "Answers"}),
			h("div", {className: `mc-qs`}, b[1].answers.map(a =>
				h("div", {}, [
					h("span", {className: "mcqa-id", innerText: `Id: ${a.id}`}),
					h("br", {}),
					h("span", {className: "mcqa-heading", innerText: `Content: ${a.content}`}),
					h("br", {}),
				]),
			)),
		]),
	))
})();
