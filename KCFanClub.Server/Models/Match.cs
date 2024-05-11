namespace KCFanClub.Server.Models
{
	public class Match
	{
		public int Id { get; set; }
		public string Opponent { get; set; }
		public string Date { get; set; }
		public string Time { get; set; }
		public string Venue { get; set; }
	}
}
