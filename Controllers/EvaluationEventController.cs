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
	public class EvaluationEventController : ControllerBase
	{
		private readonly EvaluationContext _context;

		public EvaluationEventController(EvaluationContext context)
		{
			_context = context;
		}

		// GET: api/EvaluationEvent
		[HttpGet]
		public async Task<ActionResult<IEnumerable<EvaluationEvent>>> GetEvaluationEvents()
		{
			return await _context.EvaluationEvents.ToListAsync();
		}

		// GET: api/EvaluationEvent/5
		[HttpGet("{id}")]
		public async Task<ActionResult<EvaluationEvent>> GetEvaluationEvent(long id)
		{
			var evaluationEvent = await _context.EvaluationEvents.FindAsync(id);

			if (evaluationEvent == null)
			{
				return NotFound();
			}

			return evaluationEvent;
		}

		// PUT: api/EvaluationEvent/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEvaluationEvent(long id, EvaluationEvent evaluationEvent)
		{
			if (id != evaluationEvent.Id)
			{
				return BadRequest();
			}

			_context.Entry(evaluationEvent).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!EvaluationEventExists(id))
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

		// POST: api/EvaluationEvent
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<EvaluationEvent>> PostEvaluationEvent(EvaluationEvent evaluationEvent)
		{
			_context.EvaluationEvents.Add(evaluationEvent);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetEvaluationEvent", new { id = evaluationEvent.Id }, evaluationEvent);
		}

		// DELETE: api/EvaluationEvent/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEvaluationEvent(long id)
		{
			var evaluationEvent = await _context.EvaluationEvents.FindAsync(id);
			if (evaluationEvent == null)
			{
				return NotFound();
			}

			_context.EvaluationEvents.Remove(evaluationEvent);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool EvaluationEventExists(long id)
		{
			return _context.EvaluationEvents.Any(e => e.Id == id);
		}
	}
}
