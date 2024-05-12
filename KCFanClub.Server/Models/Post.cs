using System.ComponentModel.DataAnnotations;

namespace KCFanClub.Server.Models
{
	public class Post
	{
		[Key]
		public int Id { get; set; }
		public string Username { get; set; }
		public string Comment { get; set; }
	}
}
