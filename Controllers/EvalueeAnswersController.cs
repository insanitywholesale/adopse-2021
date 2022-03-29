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
	public class EvalueeAnswersController : ControllerBase {
		private readonly EvaluationContext _context;

		public EvalueeAnswersController(EvaluationContext context) {
			_context = context;
		}

		// GET: api/EvalueeAnswers
		[HttpGet]
		public async Task<ActionResult<IEnumerable<EvalueeAnswers>>> GetEvalueeAnswerSets() {
			return await _context.EvalueeAnswerSets.ToListAsync();
		}

		// GET: api/EvalueeAnswers/5
		[HttpGet("{id}")]
		public async Task<ActionResult<EvalueeAnswers>> GetEvalueeAnswers(long id) {
			var evalueeAnswers = await _context.EvalueeAnswerSets.FindAsync(id);

			if (evalueeAnswers == null) {
				return NotFound();
			}

			return evalueeAnswers;
		}

		// PUT: api/EvalueeAnswers/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEvalueeAnswers(long id, EvalueeAnswers evalueeAnswers) {
			if (id != evalueeAnswers.Id) {
				return BadRequest();
			}

			_context.Entry(evalueeAnswers).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!EvalueeAnswersExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/EvalueeAnswers
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<EvalueeAnswers>> PostEvalueeAnswers(EvalueeAnswers evalueeAnswers) {
			_context.EvalueeAnswerSets.Add(evalueeAnswers);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetEvalueeAnswers", new { id = evalueeAnswers.Id }, evalueeAnswers);
		}

		// DELETE: api/EvalueeAnswers/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEvalueeAnswers(long id) {
			var evalueeAnswers = await _context.EvalueeAnswerSets.FindAsync(id);
			if (evalueeAnswers == null) {
				return NotFound();
			}

			_context.EvalueeAnswerSets.Remove(evalueeAnswers);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool EvalueeAnswersExists(long id) {
			return _context.EvalueeAnswerSets.Any(e => e.Id == id);
		}
	}
}
