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

	questions.append(...Object.entries(oqs).map(b => 
		h("div", {className: `question-${b[0]}`}, [
			h("h3", {className: "q-header", innerText: "Open Questions"}),
			h("span", {className: "q-id", innerText: `Id: ${b[1].id}`}),
			h("br", {}),
			h("span", {className: "q-heading", innerText: `Heading: ${b[1].heading}`}),
			h("br", {}),
			h("h4", {className: "q-header", innerText: "Answer"}),
			h("div", {className: `open-qs`}, [
				h("span", {className: "q-id", innerText: `Id: ${b[1].answer.id}`}),
				h("br", {}),
				h("span", {className: "q-heading", innerText: `Heading: ${b[1].answer.contentFromEvaluee}`}),
				h("br", {}),
			]),
		]),
	))

	questions.append(...Object.entries(mcqs).map(b => 
		h("div", {className: `question-${b[0]}`}, [
			h("h3", {className: "q-header", innerText: "Multiple Choice Questions"}),
			h("span", {className: "q-id", innerText: `Id: ${b[1].id}`}),
			h("br", {}),
			h("span", {className: "q-heading", innerText: `Heading: ${b[1].heading}`}),
			h("br", {}),
			h("h4", {className: "q-header", innerText: "Answers"}),
			h("div", {className: `mc-qs`}, b[1].answers.map(a =>
				h("div", {}, [
					h("span", {className: "q-id", innerText: `Id: ${a.id}`}),
					h("br", {}),
					h("span", {className: "q-heading", innerText: `Content: ${a.content}`}),
					h("br", {}),
				]),
			)),
		]),
	))
})();
