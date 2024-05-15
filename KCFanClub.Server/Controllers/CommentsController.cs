using KCFanClub.Server.Data;
using KCFanClub.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KCFanClub.Server.Controllers
{
	[Route("api/comments")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly ILogger<CommentsController> _logger;
		protected APIResponse _response;

		public CommentsController(ApplicationDbContext dbContext, ILogger<CommentsController> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
			_response = new();
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<APIResponse>> GetAllComments()
		{
			_logger.LogInformation("Getting all comments");

			IEnumerable<Post> comments;

			try
			{
				comments = await _dbContext.Posts.ToListAsync();

				_response.isSuccess = true;
				_response.Result = comments;
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
		public async Task<ActionResult<Post>> GetComment(int id)
		{
			try
			{
				var foundComment = await _dbContext.Posts.FindAsync(id);

				if (foundComment == null)
				{
					_logger.LogError("Get comment error with id" + id);

					return NotFound();
				}

				_response.isSuccess = true;
				_response.StatusCode = HttpStatusCode.OK;
				_response.Result = foundComment;
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
		public async Task<ActionResult<APIResponse>> PostComment([FromBody] Post commentToPost)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_response.StatusCode = HttpStatusCode.Created;
					_response.Result = commentToPost;
					_dbContext.Posts.Add(commentToPost);
					await _dbContext.SaveChangesAsync();
					return CreatedAtAction("GetMatch", new { id = commentToPost.Id }, commentToPost);
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
		/*[HttpPut("{id:int}")]
		public async Task<IActionResult> PutComment(int id, [FromBody] Post matchToUpdate)
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
		}*/

		// DELETE api/<MatchController>/5
		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<APIResponse>> DeleteComment(int id)
		{
			try
			{
				var commentToDelete = await _dbContext.Posts.FindAsync(id);
				if (commentToDelete == null)
				{
					_logger.LogError("Delete comment error with id" + id);

					return NotFound();
				}

				_dbContext.Posts.Remove(commentToDelete);
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

	}
}
