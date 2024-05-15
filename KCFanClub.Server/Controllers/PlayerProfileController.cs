using KCFanClub.Server.Data;
using KCFanClub.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KCFanClub.Server.Controllers
{
	[Route("api/players")]
	[ApiController]
	public class PlayerProfileController : ControllerBase
	{

		private readonly ApplicationDbContext _dbContext;
		private readonly ILogger<PlayerProfileController> _logger;
		protected APIResponse _response;

		public PlayerProfileController(ApplicationDbContext dbContext, ILogger<PlayerProfileController> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
			_response = new();
		}


		// GET: api/<PlayerProfileController>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<APIResponse>> GetAllPlayers()
		{
			_logger.LogInformation("Getting all players");

			IEnumerable<PlayerProfile> players;

			try
			{
				players = await _dbContext.PlayerProfile.ToListAsync();

				_response.isSuccess = true;
				_response.Result = players;
				_response.StatusCode = HttpStatusCode.OK;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.isSuccess = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}

			return _response;
		}

		// GET api/<PlayerProfileController>/5
		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<APIResponse>> GetPlayer(int id)
		{
			try
			{
				var foundPlayer = await _dbContext.PlayerProfile.FindAsync(id);

				if (foundPlayer == null)
				{
					_logger.LogError("Get player error with id" + id);

					return NotFound();
				}

				_response.isSuccess = true;
				_response.StatusCode = HttpStatusCode.OK;
				_response.Result = foundPlayer;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.isSuccess = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return Ok(_response);
		}

		// POST api/<PlayerProfileController>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<APIResponse>> PostPlayer([FromBody] PlayerProfile player)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_response.StatusCode = HttpStatusCode.Created;
					_response.Result = player;
					_dbContext.PlayerProfile.Add(player);
					await _dbContext.SaveChangesAsync();
					return CreatedAtAction("GetMatch", new { id = player.Id }, player);
				}
			}
			catch (Exception ex)
			{
				_response.isSuccess = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}

			return _response;
		}

		// PUT api/<PlayerProfileController>/5
		[HttpPut("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> PutPlayer(int id, [FromBody] PlayerProfile playerToUpdate)
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
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<APIResponse>> DeletePlayer(int id)
		{
			try
			{
				var playerToDelete = await _dbContext.PlayerProfile.FindAsync(id);
				if (playerToDelete == null)
				{
					_logger.LogError("Delete player error with id" + id);

					return NotFound();
				}

				_dbContext.PlayerProfile.Remove(playerToDelete);
				_response.isSuccess = true;
				_response.StatusCode = HttpStatusCode.NoContent;
				await _dbContext.SaveChangesAsync();

				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.isSuccess = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}

			return _response;
		}

		private bool PlayerExists(int id)
		{
			return _dbContext.PlayerProfile.Any(u => u.Id == id);
		}
	}
}
