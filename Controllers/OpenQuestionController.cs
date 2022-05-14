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
	public class OpenQuestionController : ControllerBase {
		private readonly EvaluationContext _context;

		public OpenQuestionController(EvaluationContext context) {
			_context = context;
		}

		// GET: api/OpenQuestion
		[HttpGet]
		public async Task<ActionResult<IEnumerable<OpenQuestion>>> GetOpenQuestions() {
			return await _context.OpenQuestions.Include(x => x.Answer).ToListAsync();
		}

		// GET: api/OpenQuestion/5
		[HttpGet("{id}")]
		public async Task<ActionResult<OpenQuestion>> GetOpenQuestion(long id) {
			var openQuestion = await _context.OpenQuestions.FindAsync(id);

			if (openQuestion == null) {
				return NotFound();
			}

			// get the idea from here:
			// https://stackoverflow.com/questions/7348663/c-sharp-entity-framework-how-can-i-combine-a-find-and-include-on-a-model-obje#7348694
			_context.Entry(openQuestion).Reference(x => x.Answer).Load();

			return openQuestion;
		}

		// GET: api/OpenQuestion/5/answer
		[HttpGet("{id}/answer")]
		public async Task<ActionResult<OpenAnswer>> GetOpenAnswer(long id) {
			var openQuestion = await _context.OpenQuestions.FindAsync(id);

			if (openQuestion == null) {
				return NotFound();
			}

			// get the idea from here:
			// https://stackoverflow.com/questions/7348663/c-sharp-entity-framework-how-can-i-combine-a-find-and-include-on-a-model-obje#7348694
			_context.Entry(openQuestion).Reference(x => x.Answer).Load();

			return openQuestion.Answer;
		}

		// PUT: api/OpenQuestion/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutOpenQuestion(long id, OpenQuestion openQuestion) {
			if (id != openQuestion.Id) {
				return BadRequest();
			}

			_context.Entry(openQuestion).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!OpenQuestionExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// PUT: api/OpenQuestion/5/answer
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}/answer")]
		public async Task<IActionResult> PutOpenAnswer(long id, OpenAnswer openAnswer) {
			if (id != openAnswer.Id) {
				return BadRequest();
			}

			_context.Entry(openAnswer).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!OpenQuestionExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/OpenQuestion
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<OpenQuestion>> PostOpenQuestion(OpenQuestion openQuestion) {
			_context.OpenQuestions.Add(openQuestion);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetOpenQuestion), new { id = openQuestion.Id }, openQuestion);
		}

		// POST: api/OpenQuestion/5/answer
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost("{id}/answer")]
		public async Task<ActionResult<OpenAnswer>> AddOpenAnswerToOpenQuestion(long id, OpenAnswer oa) {
			//TODO: fix adding answer to openquestion
			// Check if an ID was supplied
			if (oa.Id < 1) { // If not, create question
				_context.OpenAnswers.Add(oa);
				await _context.SaveChangesAsync(); //TODO: see if answers are saved
			} else { // If yes, load the question
				oa = await _context.OpenAnswers.FindAsync(oa.Id);
			}
			_context.OpenAnswers.Add(oa);
			return oa;
		}

		// DELETE: api/OpenQuestion/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteOpenQuestion(long id) {
			var openQuestion = await _context.OpenQuestions.FindAsync(id);
			if (openQuestion == null) {
				return NotFound();
			}

			_context.OpenQuestions.Remove(openQuestion);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool OpenQuestionExists(long id) {
			return _context.OpenQuestions.Any(e => e.Id == id);
		}
	}
}
