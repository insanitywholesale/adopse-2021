#nullable disable
using adopse_2021.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace adopse_2021.Controllers {
	[Route("/")]
	[ApiController]
	public class RootController : ControllerBase {
		private readonly EvaluationContext _context;

		public RootController(EvaluationContext context) {
			_context = context;
		}

		// GET: /
		[HttpGet]
		public ActionResult GetRoot() {
			return Ok("see the frontend at https://adopsefront.inherently.xyz/\nsee the docs at https://adopseback.inherently.xyz/swagger/index.html\nsee the source code at https://github.com/insanitywholesale/adopse-2021");
		}
	}
}
