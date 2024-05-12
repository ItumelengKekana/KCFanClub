using System.ComponentModel.DataAnnotations;

namespace KCFanClub.Server.Models
{
	public class PlayerProfile
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
		public string Nationality { get; set; }
		public string Bio { get; set; }
	}
}
