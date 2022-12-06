using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeepBoopQuiz.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeepBoopQuiz.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class EvaluationController : ControllerBase {
		private readonly QuizContext _context;

		public EvaluationController(QuizContext context) {
			_context = context;
		}

		// GET: api/Evaluation
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Evaluation>>> GetEvaluations() {
			if (_context.Evaluations == null) {
				return NotFound();
			}
			return await _context.Evaluations.ToListAsync();
		}

		// GET: api/Evaluation/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Evaluation>> GetEvaluation(long id) {
			if (_context.Evaluations == null) {
				return NotFound();
			}
			var evaluation = await _context.Evaluations.FindAsync(id);

			if (evaluation == null) {
				return NotFound();
			}

			return evaluation;
		}

		// PUT: api/Evaluation/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEvaluation(long id, Evaluation evaluation) {
			if (id != evaluation.Id) {
				return BadRequest();
			}

			_context.Entry(evaluation).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!EvaluationExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Evaluation
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Evaluation>> PostEvaluation(Evaluation evaluation) {
			if (_context.Evaluations == null) {
				return Problem("Entity set 'QuizContext.Evaluations'  is null.");
			}
			_context.Evaluations.Add(evaluation);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetEvaluation", new { id = evaluation.Id }, evaluation);
		}

		// DELETE: api/Evaluation/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEvaluation(long id) {
			if (_context.Evaluations == null) {
				return NotFound();
			}
			var evaluation = await _context.Evaluations.FindAsync(id);
			if (evaluation == null) {
				return NotFound();
			}

			_context.Evaluations.Remove(evaluation);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool EvaluationExists(long id) {
			return (_context.Evaluations?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
