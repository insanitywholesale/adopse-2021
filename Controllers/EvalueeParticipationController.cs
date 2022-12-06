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
	public class EvalueeParticipationController : ControllerBase {
		private readonly QuizContext _context;

		public EvalueeParticipationController(QuizContext context) {
			_context = context;
		}

		// GET: api/EvalueeParticipation
		[HttpGet]
		public async Task<ActionResult<IEnumerable<EvalueeParticipation>>> GetEvalueeParticipations() {
			if (_context.EvalueeParticipations == null) {
				return NotFound();
			}
			return await _context.EvalueeParticipations.ToListAsync();
		}

		// GET: api/EvalueeParticipation/5
		[HttpGet("{id}")]
		public async Task<ActionResult<EvalueeParticipation>> GetEvalueeParticipation(long id) {
			if (_context.EvalueeParticipations == null) {
				return NotFound();
			}
			var evalueeParticipation = await _context.EvalueeParticipations.FindAsync(id);

			if (evalueeParticipation == null) {
				return NotFound();
			}

			return evalueeParticipation;
		}

		// PUT: api/EvalueeParticipation/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEvalueeParticipation(long id, EvalueeParticipation evalueeParticipation) {
			if (id != evalueeParticipation.Id) {
				return BadRequest();
			}

			_context.Entry(evalueeParticipation).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!EvalueeParticipationExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/EvalueeParticipation
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<EvalueeParticipation>> PostEvalueeParticipation(EvalueeParticipation evalueeParticipation) {
			if (_context.EvalueeParticipations == null) {
				return Problem("Entity set 'QuizContext.EvalueeParticipations'  is null.");
			}
			_context.EvalueeParticipations.Add(evalueeParticipation);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetEvalueeParticipation", new { id = evalueeParticipation.Id }, evalueeParticipation);
		}

		// DELETE: api/EvalueeParticipation/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEvalueeParticipation(long id) {
			if (_context.EvalueeParticipations == null) {
				return NotFound();
			}
			var evalueeParticipation = await _context.EvalueeParticipations.FindAsync(id);
			if (evalueeParticipation == null) {
				return NotFound();
			}

			_context.EvalueeParticipations.Remove(evalueeParticipation);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool EvalueeParticipationExists(long id) {
			return (_context.EvalueeParticipations?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
