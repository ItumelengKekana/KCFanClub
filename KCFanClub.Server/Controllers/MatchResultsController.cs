using KCFanClub.Server.Data;
using KCFanClub.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace KCFanClub.Server.Controllers
{
	[Route("api/results")]
	[ApiController]
	public class MatchResultsController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;

		public MatchResultsController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public async Task<IEnumerable<MatchResult>> GetAllResults()
		{
			return await _dbContext.MatchResults.ToListAsync();
		}

		// GET api/<MatchController>/5
		[HttpGet("{id:int}")]
		public async Task<ActionResult<MatchResult>> GetResult(int id)
		{
			try
			{
				var foundMatchResult = await _dbContext.MatchResults.FindAsync(id);

				if (foundMatchResult == null)
				{
					return NotFound();
				}

				return foundMatchResult;
			}
			catch (Exception)
			{
				throw;
			}
		}

		// POST api/<MatchController>
		[HttpPost]
		public async Task<ActionResult<MatchResult>> PostMatch([FromBody] MatchResult matchResultToPost)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_dbContext.MatchResults.Add(matchResultToPost);
					await _dbContext.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				throw;
			}

			return CreatedAtAction("GetResult", new { id = matchResultToPost.Id }, matchResultToPost);
		}

		// PUT api/<MatchController>/5
		[HttpPut("{id:int}")]
		public async Task<IActionResult> PutMatchResult(int id, [FromBody] MatchResult matchToUpdate)
		{
			if (id != matchToUpdate.Id)
			{
				return BadRequest();
			}

			_dbContext.Entry(matchToUpdate).State = EntityState.Modified;

			try
			{
				await _dbContext.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MatchExists(id))
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

		// DELETE api/<MatchController>/5
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteMatchResult(int id)
		{
			var matchToDelete = await _dbContext.MatchResults.FindAsync(id);
			if (matchToDelete == null)
			{
				return NotFound();
			}

			_dbContext.MatchResults.Remove(matchToDelete);
			await _dbContext.SaveChangesAsync();

			return NoContent();
		}

		private bool MatchExists(int id)
		{
			return _dbContext.MatchResults.Any(u => u.Id == id);
		}
	}
}
