using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KCFanClub.Server.Models
{
	public class MatchResult
	{
		public int Id { get; set; }
		public string HomeTeam { get; set; }
		public string AwayTeam { get; set; }
		public string HomeScore { get; set; }
		public string AwayScore { get; set; }
		public string Highlights { get; set; }
		public string Comment { get; set; }
	}
}
