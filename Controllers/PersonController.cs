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
	public class PersonController : ControllerBase {
		private readonly QuizContext _context;

		public PersonController(QuizContext context) {
			_context = context;
		}

		// GET: api/Person
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Person>>> GetPeople() {
			if (_context.People == null) {
				return NotFound();
			}
			return await _context.People.ToListAsync();
		}

		// GET: api/Person/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Person>> GetPerson(long id) {
			if (_context.People == null) {
				return NotFound();
			}
			var person = await _context.People.FindAsync(id);

			if (person == null) {
				return NotFound();
			}

			return person;
		}

		// PUT: api/Person/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutPerson(long id, Person person) {
			if (id != person.Id) {
				return BadRequest();
			}

			_context.Entry(person).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!PersonExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Person
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Person>> PostPerson(Person person) {
			if (_context.People == null) {
				return Problem("Entity set 'QuizContext.People'  is null.");
			}
			_context.People.Add(person);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetPerson", new { id = person.Id }, person);
		}

		// DELETE: api/Person/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePerson(long id) {
			if (_context.People == null) {
				return NotFound();
			}
			var person = await _context.People.FindAsync(id);
			if (person == null) {
				return NotFound();
			}

			_context.People.Remove(person);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool PersonExists(long id) {
			return (_context.People?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
