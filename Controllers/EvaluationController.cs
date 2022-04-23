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
			return await _context.Evaluations.Include(x => x.Questions.OpenQuestions).ThenInclude(x => x.Answer).Include(x => x.Questions.MultipleChoiceQuestions).ThenInclude(x => x.Answers).ToListAsync();
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

		// GET: api/Evaluation/5/question
		[HttpGet("{id}/questions")]
		public async Task<ActionResult<Q>> GetEvaluationQuestions(long id) {
			var evaluation = await _context.Evaluations.FindAsync(id);

			if (evaluation == null) {
				return NotFound();
			}

			if (evaluation.Questions == null) {
				return NotFound();
			}

			return evaluation.Questions;
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
			//TODO: calculate grade from questions if grade is not supplied
			_context.Evaluations.Add(evaluation);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetEvaluation), new { id = evaluation.Id }, evaluation);
		}

		// POST: api/Evaluation/5/multiplechoicequestion
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost("{id}/multiplechoicequestion")]
		public async Task<ActionResult<MultipleChoiceQuestion>> AddMultipleChoiceQuestionToEvaluation(long id, MultipleChoiceQuestion mcq) {
			// If question is graded, check that grade of question totals grade of correct answers is accurate
			if (mcq.IsGraded == true) {
				var gradeTotal = 0.0;

				foreach (MultipleChoiceAnswer mca in mcq.Answers) {
					if (mca.IsCorrectAnswer == true) {
						gradeTotal += mca.Grade;
					}
				}

				// If the correct answer sum grade exceeds the question grade, return bad request
				if (gradeTotal != mcq.Grade) {
					return BadRequest();
				}
			}

			// Check if an ID was supplied
			if (mcq.Id < 1) { // If not, create question
				_context.MultipleChoiceQuestions.Add(mcq);
				await _context.SaveChangesAsync(); //TODO: see if answers are saved
			} else { // If yes, load the question
				mcq = await _context.MultipleChoiceQuestions.FindAsync(mcq.Id);
				_context.Entry(mcq).Reference(x => x.Answers).Load();
			}
			// No matter what, add the question to the evaluation
			var e = await _context.Evaluations.FindAsync(id);
			_context.Entry(e).Reference(x => x.Questions).Load();
			e.Questions.MultipleChoiceQuestions.Add(mcq);
			return mcq;
		}

		// POST: api/Evaluation/5/openquestion
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost("{id}/openquestion")]
		public async Task<ActionResult<OpenQuestion>> AddOpenQuestionToEvaluation(long id, OpenQuestion oq) {
			// Check if an ID was supplied
			if (oq.Id < 1) { // If not, create question
				_context.OpenQuestions.Add(oq);
				await _context.SaveChangesAsync(); //TODO: see if answers are saved
			} else { // If yes, load the question
				oq = await _context.OpenQuestions.FindAsync(oq.Id);
				_context.Entry(oq).Reference(x => x.Answer).Load();
			}
			// No matter what, add the question to the evaluation
			var e = await _context.Evaluations.FindAsync(id);
			_context.Entry(e).Reference(x => x.Questions).Load();
			e.Questions.OpenQuestions.Add(oq);
			return oq;
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
