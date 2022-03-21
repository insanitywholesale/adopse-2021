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
	public class EvaluationAnswerController : ControllerBase
	{
		private readonly EvaluationContext _context;

		public EvaluationAnswerController(EvaluationContext context)
		{
			_context = context;
		}

		// GET: api/EvaluationAnswer
		[HttpGet]
		public async Task<ActionResult<IEnumerable<EvaluationAnswer>>> GetAnswers()
		{
			return await _context.Answers.ToListAsync();
		}

		// GET: api/EvaluationAnswer/5
		[HttpGet("{id}")]
		public async Task<ActionResult<EvaluationAnswer>> GetEvaluationAnswer(long id)
		{
			var evaluationAnswer = await _context.Answers.FindAsync(id);

			if (evaluationAnswer == null)
			{
				return NotFound();
			}

			return evaluationAnswer;
		}

		// PUT: api/EvaluationAnswer/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEvaluationAnswer(long id, EvaluationAnswer evaluationAnswer)
		{
			if (id != evaluationAnswer.Id)
			{
				return BadRequest();
			}

			_context.Entry(evaluationAnswer).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!EvaluationAnswerExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/EvaluationAnswer
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<EvaluationAnswer>> PostEvaluationAnswer(EvaluationAnswer evaluationAnswer)
		{
			_context.Answers.Add(evaluationAnswer);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetEvaluationAnswer", new { id = evaluationAnswer.Id }, evaluationAnswer);
		}

		// DELETE: api/EvaluationAnswer/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEvaluationAnswer(long id)
		{
			var evaluationAnswer = await _context.Answers.FindAsync(id);
			if (evaluationAnswer == null)
			{
				return NotFound();
			}

			_context.Answers.Remove(evaluationAnswer);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool EvaluationAnswerExists(long id)
		{
			return _context.Answers.Any(e => e.Id == id);
		}
	}
}
