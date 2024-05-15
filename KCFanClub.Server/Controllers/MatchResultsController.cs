using KCFanClub.Server.Data;
using KCFanClub.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace KCFanClub.Server.Controllers
{
	[Route("api/results")]
	[ApiController]
	public class MatchResultsController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly ILogger<MatchResultsController> _logger;
		protected APIResponse _response;

		public MatchResultsController(ApplicationDbContext dbContext, ILogger<MatchResultsController> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
			_response = new();
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<APIResponse>> GetAllResults()
		{
			_logger.LogInformation("Getting all matches");

			IEnumerable<MatchResult> results;

			try
			{
				results = await _dbContext.MatchResults.ToListAsync();

				_response.isSuccess = true;
				_response.Result = results;
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
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<APIResponse>> GetResult(int id)
		{
			try
			{
				var foundMatchResult = await _dbContext.MatchResults.FindAsync(id);

				if (foundMatchResult == null)
				{
					_logger.LogError("Get Result error with id" + id);
					return NotFound();
				}

				_response.isSuccess = true;
				_response.StatusCode = HttpStatusCode.OK;
				_response.Result = foundMatchResult;
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
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<APIResponse>> PostMatch([FromBody] MatchResult matchResultToPost)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_response.StatusCode = HttpStatusCode.Created;
					_response.Result = matchResultToPost;
					_dbContext.MatchResults.Add(matchResultToPost);
					await _dbContext.SaveChangesAsync();

					return CreatedAtAction("GetResult", new { id = matchResultToPost.Id }, matchResultToPost);
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
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
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
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<APIResponse>> DeleteMatchResult(int id)
		{
			try
			{
				var matchToDelete = await _dbContext.MatchResults.FindAsync(id);
				if (matchToDelete == null)
				{
					_logger.LogError("Delete result error with id" + id);

					return NotFound();
				}

				_dbContext.MatchResults.Remove(matchToDelete);
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
			return _dbContext.MatchResults.Any(u => u.Id == id);
		}
	}
}
