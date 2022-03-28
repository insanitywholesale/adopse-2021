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
	public class EvalueeController : ControllerBase {
		private readonly EvaluationContext _context;

		public EvalueeController(EvaluationContext context) {
			_context = context;
		}

		// GET: api/Evaluee
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Evaluee>>> GetEvaluees() {
			return await _context.Evaluees.ToListAsync();
		}

		// GET: api/Evaluee/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Evaluee>> GetEvaluee(long id) {
			var evaluee = await _context.Evaluees.FindAsync(id);

			if (evaluee == null) {
				return NotFound();
			}

			return evaluee;
		}

		// PUT: api/Evaluee/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEvaluee(long id, Evaluee evaluee) {
			if (id != evaluee.Id) {
				return BadRequest();
			}

			_context.Entry(evaluee).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!EvalueeExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Evaluee
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Evaluee>> PostEvaluee(Evaluee evaluee) {
			_context.Evaluees.Add(evaluee);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetEvaluee", new { id = evaluee.Id }, evaluee);
		}

		// DELETE: api/Evaluee/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEvaluee(long id) {
			var evaluee = await _context.Evaluees.FindAsync(id);
			if (evaluee == null) {
				return NotFound();
			}

			_context.Evaluees.Remove(evaluee);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool EvalueeExists(long id) {
			return _context.Evaluees.Any(e => e.Id == id);
		}
	}
}
