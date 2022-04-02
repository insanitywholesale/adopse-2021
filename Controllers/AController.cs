#nullable disable
using adopse_2021.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace adopse_2021.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class AController : ControllerBase {
		private readonly EvaluationContext _context;

		public AController(EvaluationContext context) {
			_context = context;
		}

		// GET: api/A
		[HttpGet]
		public async Task<ActionResult<A>> GetAs() {
			var a = new A();
			a.OpenAnswers = await _context.OpenAnswers.ToListAsync();
			a.MultipleChoiceAnswers = await _context.MultipleChoiceAnswers.ToListAsync();
			return a;
		}

		private bool AExists(long id) {
			return _context.As.Any(e => e.Id == id);
		}
	}
}
