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
	public class AController : ControllerBase {
		private readonly EvaluationContext _context;

		public AController(EvaluationContext context) {
			_context = context;
		}

		// GET: api/A
		[HttpGet]
		public async Task<ActionResult<IEnumerable<A>>> GetAs() {
			return await _context.As.ToListAsync();
		}

		// GET: api/A/5
		[HttpGet("{id}")]
		public async Task<ActionResult<A>> GetA(long id) {
			var a = await _context.As.FindAsync(id);

			if (a == null) {
				return NotFound();
			}

			return a;
		}

		// PUT: api/A/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutA(long id, A a) {
			if (id != a.Id) {
				return BadRequest();
			}

			_context.Entry(a).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!AExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/A
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<A>> PostA(A a) {
			_context.As.Add(a);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetA", new { id = a.Id }, a);
		}

		// DELETE: api/A/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteA(long id) {
			var a = await _context.As.FindAsync(id);
			if (a == null) {
				return NotFound();
			}

			_context.As.Remove(a);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool AExists(long id) {
			return _context.As.Any(e => e.Id == id);
		}
	}
}
