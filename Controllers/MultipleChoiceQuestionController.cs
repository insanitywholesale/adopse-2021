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
	public class MultipleChoiceQuestionController : ControllerBase {
		private readonly QuizContext _context;

		public MultipleChoiceQuestionController(QuizContext context) {
			_context = context;
		}

		// GET: api/MultipleChoiceQuestion
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MultipleChoiceQuestion>>> GetMultipleChoiceQuestions() {
			if (_context.MultipleChoiceQuestions == null) {
				return NotFound();
			}
			return await _context.MultipleChoiceQuestions.Include(x => x.Answers).ToListAsync();
		}

		// GET: api/MultipleChoiceQuestion/5
		[HttpGet("{id}")]
		public async Task<ActionResult<MultipleChoiceQuestion>> GetMultipleChoiceQuestion(long id) {
			if (_context.MultipleChoiceQuestions == null) {
				return NotFound();
			}
			var multipleChoiceQuestion = await _context.MultipleChoiceQuestions.FindAsync(id);

			if (multipleChoiceQuestion == null) {
				return NotFound();
			}

			// get the idea from here:
			// https://stackoverflow.com/questions/7348663/c-sharp-entity-framework-how-can-i-combine-a-find-and-in    clude-on-a-model-obje#7348694
			_context.Entry(multipleChoiceQuestion).Reference(x => x.Answers).Load();

			return multipleChoiceQuestion;
		}

		// PUT: api/MultipleChoiceQuestion/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMultipleChoiceQuestion(long id, MultipleChoiceQuestion multipleChoiceQuestion) {
			if (id != multipleChoiceQuestion.Id) {
				return BadRequest();
			}

			_context.Entry(multipleChoiceQuestion).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!MultipleChoiceQuestionExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/MultipleChoiceQuestion
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<MultipleChoiceQuestion>> PostMultipleChoiceQuestion(MultipleChoiceQuestion multipleChoiceQuestion) {
			if (_context.MultipleChoiceQuestions == null) {
				return Problem("Entity set 'QuizContext.MultipleChoiceQuestions'  is null.");
			}
			// If question is graded, check that grade of question totals grade of correct answers is accurate
			if (multipleChoiceQuestion.IsGraded == true) {
				var gradeTotal = 0.0;

				foreach (MultipleChoiceAnswer mca in multipleChoiceQuestion.Answers) {
					if (mca.IsCorrectAnswer == true) {
						gradeTotal += mca.Grade;
					}
				}
				// If the correct answer sum grade exceeds the question grade, return bad request
				if (gradeTotal != multipleChoiceQuestion.Grade) {

					return BadRequest();
				}
			}

			_context.MultipleChoiceQuestions.Add(multipleChoiceQuestion);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetMultipleChoiceQuestion", new { id = multipleChoiceQuestion.Id }, multipleChoiceQuestion);
		}

		// DELETE: api/MultipleChoiceQuestion/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMultipleChoiceQuestion(long id) {
			if (_context.MultipleChoiceQuestions == null) {
				return NotFound();
			}
			var multipleChoiceQuestion = await _context.MultipleChoiceQuestions.FindAsync(id);
			if (multipleChoiceQuestion == null) {
				return NotFound();
			}

			_context.MultipleChoiceQuestions.Remove(multipleChoiceQuestion);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool MultipleChoiceQuestionExists(long id) {
			return (_context.MultipleChoiceQuestions?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
