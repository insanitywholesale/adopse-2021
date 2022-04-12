import { g, h, x } from "./xeact.js";

(async () => {
	const baseURL = "http://localhost:5000";
	const resp = await fetch(baseURL+"/swagger/v1/swagger.json");
	console.log("resp:", resp);
	const data = await resp.json();
	console.log("data:", data);

	let root = g("root");
	x(root);

	let ver = data.openapi;
	
	root.append(h("div", {className: "openapi-version", innerText: `${ver}`}));

	root.append(...Object.entries(data.paths).map(b => 
		h("div", {}, h("p", {className: "path-name", innerText: `${b[0]}`}))
	));
})();
