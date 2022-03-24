#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using adopse_2021.Models;

namespace adopse_2021.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QController : ControllerBase
	{
		private readonly EvaluationContext _context;

		public QController(EvaluationContext context)
		{
			_context = context;
		}

		// GET: api/Q
		[HttpGet]
		public async Task<ActionResult<Q>> GetQs()
		{
			var q = new Q();
			q.OpenQuestions = await _context.OpenQuestions.ToListAsync();
			q.MultipleChoiceQuestions = await _context.MultipleChoiceQuestions.ToListAsync();
			return q;
		}

		private bool QExists(long id)
		{
			return _context.Qs.Any(e => e.Id == id);
		}
	}
}
