#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using adopse_2021.Models;

namespace adopse_2021.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OpenAnswerController : ControllerBase
	{
		private readonly EvaluationContext _context;

		public OpenAnswerController(EvaluationContext context)
		{
			_context = context;
		}

		// GET: api/OpenAnswer
		[HttpGet]
		public async Task<ActionResult<IEnumerable<OpenAnswer>>> GetOpenAnswers()
		{
			return await _context.OpenAnswers.ToListAsync();
		}

		// GET: api/OpenAnswer/5
		[HttpGet("{id}")]
		public async Task<ActionResult<OpenAnswer>> GetOpenAnswer(long id)
		{
			var openAnswer = await _context.OpenAnswers.FindAsync(id);

			if (openAnswer == null)
			{
				return NotFound();
			}

			return openAnswer;
		}

		// PUT: api/OpenAnswer/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutOpenAnswer(long id, OpenAnswer openAnswer)
		{
			if (id != openAnswer.Id)
			{
				return BadRequest();
			}

			_context.Entry(openAnswer).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!OpenAnswerExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/OpenAnswer
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<OpenAnswer>> PostOpenAnswer(OpenAnswer openAnswer)
		{
			_context.OpenAnswers.Add(openAnswer);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetOpenAnswer", new { id = openAnswer.Id }, openAnswer);
		}

		// DELETE: api/OpenAnswer/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteOpenAnswer(long id)
		{
			var openAnswer = await _context.OpenAnswers.FindAsync(id);
			if (openAnswer == null)
			{
				return NotFound();
			}

			_context.OpenAnswers.Remove(openAnswer);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool OpenAnswerExists(long id)
		{
			return _context.OpenAnswers.Any(e => e.Id == id);
		}
	}
}
