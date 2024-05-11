using KCFanClub.Server.Data;
using KCFanClub.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace KCFanClub.Server.Controllers
{
	[Route("api/matches")]
	[ApiController]
	public class MatchController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;

		public MatchController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public async Task<IEnumerable<Match>> GetAllMatches()
		{
			return await _dbContext.Match.ToListAsync();
		}

		// GET api/<MatchController>/5
		[HttpGet("{id:int}")]
		public async Task<ActionResult<Match>> GetMatch(int id)
		{
			try
			{
				var foundMatch = await _dbContext.Match.FindAsync(id);

				if (foundMatch == null)
				{
					return NotFound();
				}

				return foundMatch;
			}
			catch (Exception)
			{
				throw;
			}
		}

		// POST api/<MatchController>
		[HttpPost]
		public async Task<ActionResult<Match>> PostMatch(Match matchToPost)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_dbContext.Match.Add(matchToPost);
					await _dbContext.SaveChangesAsync();
				}
			}
			catch (Exception)
			{
				throw;
			}

			return CreatedAtAction("GetMatch", new { id = matchToPost.Id }, matchToPost);
		}

		// PUT api/<MatchController>/5
		[HttpPut("{id:int}")]
		public async Task<IActionResult> PutMatch(int id, Match matchToUpdate)
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
		public async Task<IActionResult> DeleteMatch(int id)
		{
			var matchToDelete = await _dbContext.Match.FindAsync(id);
			if (matchToDelete == null)
			{
				return NotFound();
			}

			_dbContext.Match.Remove(matchToDelete);
			await _dbContext.SaveChangesAsync();

			return NoContent();
		}

		private bool MatchExists(int id)
		{
			return _dbContext.Match.Any(u => u.Id == id);
		}
	}
}
