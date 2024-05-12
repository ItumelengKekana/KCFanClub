using KCFanClub.Server.Data;
using KCFanClub.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KCFanClub.Server.Controllers
{
	[Route("api/players")]
	[ApiController]
	public class PlayerProfileController : ControllerBase
	{

		private readonly ApplicationDbContext _dbContext;

		public PlayerProfileController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}


		// GET: api/<PlayerProfileController>
		[HttpGet]
		public async Task<IEnumerable<PlayerProfile>> GetAllPlayers()
		{
			return await _dbContext.PlayerProfile.ToListAsync();
		}

		// GET api/<PlayerProfileController>/5
		[HttpGet("{id:int}")]
		public async Task<ActionResult<PlayerProfile>> GetPlayer(int id)
		{
			try
			{
				var foundPlayer = await _dbContext.PlayerProfile.FindAsync(id);

				if (foundPlayer == null)
				{
					return NotFound();
				}

				return foundPlayer;
			}
			catch (Exception)
			{
				throw;
			}
		}

		// POST api/<PlayerProfileController>
		[HttpPost]
		public async Task<IActionResult> PostPlayer([FromBody] PlayerProfile player)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_dbContext.PlayerProfile.Add(player);
					await _dbContext.SaveChangesAsync();
				}
			}
			catch (Exception)
			{
				throw;
			}

			return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
		}

		// PUT api/<PlayerProfileController>/5
		[HttpPut("{id:int}")]
		public async Task<IActionResult> PutPlayer(int id,[FromBody] PlayerProfile playerToUpdate)
		{
			if (id != playerToUpdate.Id)
			{
				return BadRequest();
			}

			_dbContext.Entry(playerToUpdate).State = EntityState.Modified;

			try
			{
				await _dbContext.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PlayerExists(id))
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

		// DELETE api/<PlayerProfileController>/5
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeletePlayer(int id)
		{
			var playerToDelete = await _dbContext.PlayerProfile.FindAsync(id);
			if (playerToDelete == null)
			{
				return NotFound();
			}

			_dbContext.PlayerProfile.Remove(playerToDelete);
			await _dbContext.SaveChangesAsync();

			return NoContent();
		}

		private bool PlayerExists(int id)
		{
			return _dbContext.Match.Any(u => u.Id == id);
		}
	}
}
