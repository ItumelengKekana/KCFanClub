using KCFanClub.Server.Data;
using KCFanClub.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KCFanClub.Server.Controllers
{
	[Route("api/comments")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;

		public CommentsController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public async Task<IEnumerable<Post>> GetAllComments()
		{
			return await _dbContext.Posts.ToListAsync();
		}

		// GET api/<MatchController>/5
		[HttpGet("{id:int}")]
		public async Task<ActionResult<Post>> GetComment(int id)
		{
			try
			{
				var foundComment = await _dbContext.Posts.FindAsync(id);

				if (foundComment == null)
				{
					return NotFound();
				}

				return foundComment;
			}
			catch (Exception)
			{
				throw;
			}
		}

		// POST api/<MatchController>
		[HttpPost]
		public async Task<ActionResult<Post>> PostComment([FromBody] Post commentToPost)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_dbContext.Posts.Add(commentToPost);
					await _dbContext.SaveChangesAsync();
				}
			}
			catch (Exception)
			{
				throw;
			}

			return CreatedAtAction("GetComment", new { id = commentToPost.Id }, commentToPost);
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
		public async Task<IActionResult> DeleteComment(int id)
		{
			var commentToDelete = await _dbContext.Posts.FindAsync(id);
			if (commentToDelete == null)
			{
				return NotFound();
			}

			_dbContext.Posts.Remove(commentToDelete);
			await _dbContext.SaveChangesAsync();

			return NoContent();
		}

		/*private bool MatchExists(int id)
		{
			return _dbContext.Match.Any(u => u.Id == id);
		}*/
	}
}
