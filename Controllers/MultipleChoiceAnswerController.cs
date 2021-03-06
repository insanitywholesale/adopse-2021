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
	public class MultipleChoiceAnswerController : ControllerBase {
		private readonly EvaluationContext _context;

		public MultipleChoiceAnswerController(EvaluationContext context) {
			_context = context;
		}

		// GET: api/MultipleChoiceAnswer
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MultipleChoiceAnswer>>> GetMultipleChoiceAnswers() {
			return await _context.MultipleChoiceAnswers.ToListAsync();
		}

		// GET: api/MultipleChoiceAnswer/5
		[HttpGet("{id}")]
		public async Task<ActionResult<MultipleChoiceAnswer>> GetMultipleChoiceAnswer(long id) {
			var multipleChoiceAnswer = await _context.MultipleChoiceAnswers.FindAsync(id);

			if (multipleChoiceAnswer == null) {
				return NotFound();
			}

			return multipleChoiceAnswer;
		}

		// PUT: api/MultipleChoiceAnswer/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMultipleChoiceAnswer(long id, MultipleChoiceAnswer multipleChoiceAnswer) {
			if (id != multipleChoiceAnswer.Id) {
				return BadRequest();
			}

			_context.Entry(multipleChoiceAnswer).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!MultipleChoiceAnswerExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/MultipleChoiceAnswer
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<MultipleChoiceAnswer>> PostMultipleChoiceAnswer(MultipleChoiceAnswer multipleChoiceAnswer) {
			_context.MultipleChoiceAnswers.Add(multipleChoiceAnswer);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetMultipleChoiceAnswer), new { id = multipleChoiceAnswer.Id }, multipleChoiceAnswer);
		}

		// DELETE: api/MultipleChoiceAnswer/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMultipleChoiceAnswer(long id) {
			var multipleChoiceAnswer = await _context.MultipleChoiceAnswers.FindAsync(id);
			if (multipleChoiceAnswer == null) {
				return NotFound();
			}

			_context.MultipleChoiceAnswers.Remove(multipleChoiceAnswer);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool MultipleChoiceAnswerExists(long id) {
			return _context.MultipleChoiceAnswers.Any(e => e.Id == id);
		}
	}
}
