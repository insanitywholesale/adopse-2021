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
	public class EvaluationController : ControllerBase {
		private readonly EvaluationContext _context;

		public EvaluationController(EvaluationContext context) {
			_context = context;
		}

		// GET: api/Evaluation
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Evaluation>>> GetEvaluations() {
			return await _context.Evaluations.ToListAsync();
		}

		// GET: api/Evaluation/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Evaluation>> GetEvaluation(long id) {
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
			_context.Evaluations.Add(evaluation);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetEvaluation", new { id = evaluation.Id }, evaluation);
		}

		// DELETE: api/Evaluation/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEvaluation(long id) {
			var evaluation = await _context.Evaluations.FindAsync(id);
			if (evaluation == null) {
				return NotFound();
			}

			_context.Evaluations.Remove(evaluation);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool EvaluationExists(long id) {
			return _context.Evaluations.Any(e => e.Id == id);
		}
	}
}
