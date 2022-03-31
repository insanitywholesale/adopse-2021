import { g, h, x } from "./xeact.js";

(async () => {
	const baseURL = "http://localhost:5000/api";
	const resp = await fetch(baseURL+"/evaluation");
	console.log("resp:", resp);
	const data = await resp.json();
	console.log("data:", data);

	let evals = g("eval-root");
	x(evals);

	evals.append(...Object.entries(data).map(b => 
		h("div", {className: `evals-${b[0]}`}, [
			h("div", {className: `eval-details-${b[0]}`}, [
				h("span", {className: "eval-id", innerText: `Eval ID: ${b[1].id}`}),
				h("br", {}),
				h("span", {className: "eval-title", innerText: `Eval Title: ${b[1].title}`}),
				h("br", {}),
				h("div", {className: `eval-${b[0]}-questions`}, b[1].questions.map(q =>
					h("div", {}, [
						h("span", {className: "q-id", innerText: `Id: ${q.id}`}),
						h("br", {}),
						h("span", {className: "q-heading", innerText: `Heading: ${q.heading}`}),
					])
				)),
				h("br", {}),
			]),
		])
	))
})();
