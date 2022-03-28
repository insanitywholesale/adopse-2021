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
	public class EvaluatorController : ControllerBase {
		private readonly EvaluationContext _context;

		public EvaluatorController(EvaluationContext context) {
			_context = context;
		}

		// GET: api/Evaluator
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Evaluator>>> GetEvaluators() {
			return await _context.Evaluators.ToListAsync();
		}

		// GET: api/Evaluator/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Evaluator>> GetEvaluator(long id) {
			var evaluator = await _context.Evaluators.FindAsync(id);

			if (evaluator == null) {
				return NotFound();
			}

			return evaluator;
		}

		// PUT: api/Evaluator/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEvaluator(long id, Evaluator evaluator) {
			if (id != evaluator.Id) {
				return BadRequest();
			}

			_context.Entry(evaluator).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!EvaluatorExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Evaluator
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Evaluator>> PostEvaluator(Evaluator evaluator) {
			_context.Evaluators.Add(evaluator);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetEvaluator", new { id = evaluator.Id }, evaluator);
		}

		// DELETE: api/Evaluator/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEvaluator(long id) {
			var evaluator = await _context.Evaluators.FindAsync(id);
			if (evaluator == null) {
				return NotFound();
			}

			_context.Evaluators.Remove(evaluator);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool EvaluatorExists(long id) {
			return _context.Evaluators.Any(e => e.Id == id);
		}
	}
}
