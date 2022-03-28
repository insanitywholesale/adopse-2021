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
	public class OrganizationController : ControllerBase {
		private readonly EvaluationContext _context;

		public OrganizationController(EvaluationContext context) {
			_context = context;
		}

		// GET: api/Organization
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Organization>>> GetOrganization() {
			return await _context.Organization.ToListAsync();
		}

		// GET: api/Organization/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Organization>> GetOrganization(long id) {
			var organization = await _context.Organization.FindAsync(id);

			if (organization == null) {
				return NotFound();
			}

			return organization;
		}

		// PUT: api/Organization/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutOrganization(long id, Organization organization) {
			if (id != organization.Id) {
				return BadRequest();
			}

			_context.Entry(organization).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!OrganizationExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Organization
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Organization>> PostOrganization(Organization organization) {
			_context.Organization.Add(organization);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetOrganization", new { id = organization.Id }, organization);
		}

		// DELETE: api/Organization/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteOrganization(long id) {
			var organization = await _context.Organization.FindAsync(id);
			if (organization == null) {
				return NotFound();
			}

			_context.Organization.Remove(organization);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool OrganizationExists(long id) {
			return _context.Organization.Any(e => e.Id == id);
		}
	}
}
