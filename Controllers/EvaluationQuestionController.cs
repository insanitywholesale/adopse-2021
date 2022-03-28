#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using adopse_2021.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace adopse_2021.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class EvaluationQuestionController : ControllerBase {
		private readonly EvaluationContext _context;

		public EvaluationQuestionController(EvaluationContext context) {
			_context = context;
		}

		// GET: api/EvaluationQuestion
		[HttpGet]
		public async Task<ActionResult<IEnumerable<EvaluationQuestion>>> GetQuestions() {
			return await _context.Questions.ToListAsync();
		}

		// GET: api/EvaluationQuestion/5
		[HttpGet("{id}")]
		public async Task<ActionResult<EvaluationQuestion>> GetEvaluationQuestion(long id) {
			var evaluationQuestion = await _context.Questions.FindAsync(id);

			if (evaluationQuestion == null) {
				return NotFound();
			}

			return evaluationQuestion;
		}

		// PUT: api/EvaluationQuestion/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEvaluationQuestion(long id, EvaluationQuestion evaluationQuestion) {
			if (id != evaluationQuestion.Id) {
				return BadRequest();
			}

			_context.Entry(evaluationQuestion).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!EvaluationQuestionExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/EvaluationQuestion
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<EvaluationQuestion>> PostEvaluationQuestion(EvaluationQuestion evaluationQuestion) {
			_context.Questions.Add(evaluationQuestion);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetEvaluationQuestion", new { id = evaluationQuestion.Id }, evaluationQuestion);
		}

		// DELETE: api/EvaluationQuestion/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEvaluationQuestion(long id) {
			var evaluationQuestion = await _context.Questions.FindAsync(id);
			if (evaluationQuestion == null) {
				return NotFound();
			}

			_context.Questions.Remove(evaluationQuestion);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool EvaluationQuestionExists(long id) {
			return _context.Questions.Any(e => e.Id == id);
		}
	}
}
