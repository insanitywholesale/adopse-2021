#nullable disable
using adopse_2021.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace adopse_2021.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class QController : ControllerBase {
		private readonly EvaluationContext _context;

		public QController(EvaluationContext context) {
			_context = context;
		}

		// GET: api/Q
		[HttpGet]
		public async Task<ActionResult<Q>> GetQs() {
			var q = new Q();
			q.OpenQuestions = await _context.OpenQuestions.Include(x => x.Answer).ToListAsync();
			q.MultipleChoiceQuestions = await _context.MultipleChoiceQuestions.Include(x => x.Answers).ToListAsync();
			return q;
		}

		private bool QExists(long id) {
			return _context.Qs.Any(e => e.Id == id);
		}
	}
}
