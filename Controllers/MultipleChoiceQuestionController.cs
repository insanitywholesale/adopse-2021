#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using adopse_2021.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace adopse_2021.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class MultipleChoiceQuestionController : ControllerBase {
		private readonly EvaluationContext _context;

		public MultipleChoiceQuestionController(EvaluationContext context) {
			_context = context;
		}

		// GET: api/MultipleChoiceQuestion
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MultipleChoiceQuestion>>> GetMultipleChoiceQuestions() {
			return await _context.MultipleChoiceQuestions.Include(x => x.Answers).ToListAsync();
		}

		// GET: api/MultipleChoiceQuestion/5
		[HttpGet("{id}")]
		public async Task<ActionResult<MultipleChoiceQuestion>> GetMultipleChoiceQuestion(long id) {
			var multipleChoiceQuestion = await _context.MultipleChoiceQuestions.FindAsync(id);

			if (multipleChoiceQuestion == null) {
				return NotFound();
			}

			// get the idea from here:
			// https://stackoverflow.com/questions/7348663/c-sharp-entity-framework-how-can-i-combine-a-find-and-include-on-a-model-obje#7348694
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
			_context.MultipleChoiceQuestions.Add(multipleChoiceQuestion);
			await _context.SaveChangesAsync();

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
					// Fancy error message
					//return Problem(
					//	statusCode: 400,
					//	title: "The question is graded but the sum total grade of the correct answers exceeds the grade of the question"
					//);

					// Using ModelState
					//var modelState = new ModelStateDictionary();
					//modelState.AddModelError("Grade", "Grade bad.");
					//return BadRequest(modelState);

					// Default
					return BadRequest();
				}
			}

			return CreatedAtAction(nameof(GetMultipleChoiceQuestion), new { id = multipleChoiceQuestion.Id }, multipleChoiceQuestion);
		}

		// DELETE: api/MultipleChoiceQuestion/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMultipleChoiceQuestion(long id) {
			var multipleChoiceQuestion = await _context.MultipleChoiceQuestions.FindAsync(id);
			if (multipleChoiceQuestion == null) {
				return NotFound();
			}

			_context.MultipleChoiceQuestions.Remove(multipleChoiceQuestion);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool MultipleChoiceQuestionExists(long id) {
			return _context.MultipleChoiceQuestions.Any(e => e.Id == id);
		}
	}
}
