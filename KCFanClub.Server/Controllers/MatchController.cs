using KCFanClub.Server.Data;
using KCFanClub.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace KCFanClub.Server.Controllers
{
	[Route("api/matches")]
	[ApiController]
	public class MatchController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly ILogger<MatchController> _logger;
		protected APIResponse _response;

		public MatchController(ApplicationDbContext dbContext, ILogger<MatchController> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
			_response = new();
		}

		[HttpGet]
		public async Task<ActionResult<APIResponse>> GetAllMatches()
		{
			_logger.LogInformation("Getting all matches");

			IEnumerable<Match> matchList;

			try
			{
				matchList = await _dbContext.Match.ToListAsync();

				_response.isSuccess = true;
				_response.Result = matchList;
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

		// GET api/<MatchController>/5
		[HttpGet("{id:int}")]
		public async Task<ActionResult<APIResponse>> GetMatch(int id)
		{
			try
			{
				var foundMatch = await _dbContext.Match.FindAsync(id);

				if (foundMatch == null)
				{
					_logger.LogError("Get Match error with id" + id);

					return NotFound();
				}

				_response.isSuccess = true;
				_response.StatusCode = HttpStatusCode.OK;
				_response.Result = foundMatch;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.isSuccess = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return Ok(_response);
		}

		// POST api/<MatchController>
		[HttpPost]
		public async Task<ActionResult<APIResponse>> PostMatch([FromBody] Match matchToPost)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_response.StatusCode = HttpStatusCode.Created;
					_response.Result = matchToPost;
					_dbContext.Match.Add(matchToPost);
					await _dbContext.SaveChangesAsync();
					return CreatedAtAction("GetMatch", new { id = matchToPost.Id }, matchToPost);
				}
			}
			catch (Exception ex)
			{
				_response.isSuccess = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}

			return _response;
		}

		// PUT api/<MatchController>/5
		[HttpPut("{id:int}")]
		public async Task<IActionResult> PutMatch(int id, [FromBody] Match matchToUpdate)
		{
			if (id != matchToUpdate.Id)
			{
				_logger.LogError("Update Match error with id" + id);

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
		public async Task<ActionResult<APIResponse>> DeleteMatch(int id)
		{
			try
			{
				var matchToDelete = await _dbContext.Match.FindAsync(id);
				if (matchToDelete == null)
				{
					_logger.LogError("Delete Match error with id" + id);

					return NotFound();
				}

				_dbContext.Match.Remove(matchToDelete);
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

		private bool MatchExists(int id)
		{
			return _dbContext.Match.Any(u => u.Id == id);
		}
	}
}
