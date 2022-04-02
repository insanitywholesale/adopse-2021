import { g, h, x } from "./xeact.js";

(async () => {
	const baseURL = "http://localhost:5000/docs/swagger";
	const resp = await fetch(baseURL+"/something.swagger.json");
	console.log("resp:", resp);
	const data = await resp.json();
	console.log("data:", data);

	let root = g("root");
	x(root);

	questions.append(...Object.entries(data).map(b => 
		console.log(b[0]);
		console.log(b[1]);
		h("div", {className: "class-id", innerText: "yoink"}, b[1].map(item =>
			h("p", {className: "class-id", innerText: "oomfie"})
		))
	);
})();
