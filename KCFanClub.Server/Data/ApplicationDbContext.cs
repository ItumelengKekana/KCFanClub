using KCFanClub.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace KCFanClub.Server.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Match> Match { get; set; }
		public DbSet<PlayerProfile> PlayerProfile { get; set; }
		public DbSet<MatchResult> MatchResults { get; set; }
		public DbSet<Post> Posts { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Match>().HasData(
				new Match
				{
					Id = 1,
					Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)).ToString(),
					Opponent = "Orlando Pirates",
					Time = DateTime.Now.AddDays(5).ToString("hh:00 tt"),
					Venue = "Orlando Stadium"
				},
				new Match
				{
					Id = 2,
					Date = DateOnly.FromDateTime(DateTime.Now.AddDays(7)).ToString(),
					Opponent = "Golden Arrows",
					Time = DateTime.Now.AddDays(7).ToString("hh:00 tt"),
					Venue = "Lamontville Stadium"
				},
				new Match
				{
					Id = 3,
					Date = DateOnly.FromDateTime(DateTime.Now.AddDays(10)).ToString(),
					Opponent = "Bloemfontein Celtics",
					Time = DateTime.Now.AddDays(9).ToString("hh:00 tt"),
					Venue = "Bloemfontein Stadium"
				},
				new Match
				{
					Id = 4,
					Date = DateOnly.FromDateTime(DateTime.Now.AddDays(14)).ToString(),
					Opponent = "Mamelodi Sundowns",
					Time = DateTime.Now.AddDays(11).ToString("hh:00 tt"),
					Venue = "HM Pitje Stadium"
				},
				new Match
				{
					Id = 5,
					Date = DateOnly.FromDateTime(DateTime.Now.AddDays(19)).ToString(),
					Opponent = "Moroka Swallows",
					Time = DateTime.Now.AddDays(15).ToString("hh:00 tt"),
					Venue = "Moroka Stadium"
				}
			);

			modelBuilder.Entity<PlayerProfile>().HasData(
				new PlayerProfile
				{
					Id = 1,
					Name = "Itumeleng Khune",
					Nationality = "South African",
					Position = "Goalkeeper",
					Bio = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",
				},
				new PlayerProfile
				{
					Id = 2,
					Name = "Jasond González",
					Nationality = "Colombian",
					Position = "Forward",
					Bio = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",
				},
				new PlayerProfile
				{
					Id = 3,
					Name = "Ashley Du Preez",
					Nationality = "South African",
					Position = "Forward",
					Bio = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",
				},
				new PlayerProfile
				{
					Id = 4,
					Name = "Mfundo Vilakazi",
					Nationality = "South African",
					Position = "Midfielder",
					Bio = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",
				},
				new PlayerProfile
				{
					Id = 5,
					Name = "Edson Castillo",
					Nationality = "Venezuelan",
					Position = "Midfielder",
					Bio = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",
				},
				new PlayerProfile
				{
					Id = 6,
					Name = "Edmilson Dove",
					Nationality = "Mozambique",
					Position = "Defender",
					Bio = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",
				},
				new PlayerProfile
				{
					Id = 7,
					Name = "Thatayaone Ditlhokwe",
					Nationality = "Botswana",
					Position = "Defender",
					Bio = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",
				},
				new PlayerProfile
				{
					Id = 8,
					Name = "Njabulo Ngcobo",
					Nationality = "South African",
					Position = "Defender",
					Bio = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",
				}
			);

			modelBuilder.Entity<MatchResult>().HasData(
				new MatchResult
				{
					Id = 1,
					HomeTeam = "Kaizer Chiefs",
					AwayTeam = "Orlando Pirates",
					AwayScore = "0",
					HomeScore = "3",
				},
				new MatchResult
				{
					Id = 2,
					HomeTeam = "Polokwane City",
					AwayTeam = "Kaizer Chiefs",
					AwayScore = "2",
					HomeScore = "1",
				},
				new MatchResult
				{
					Id = 3,
					HomeTeam = "Kaizer Chiefs",
					AwayTeam = "TS Galaxy",
					AwayScore = "0",
					HomeScore = "1",
				},
				new MatchResult
				{
					Id = 4,
					HomeTeam = "Kaizer Chiefs",
					AwayTeam = "AmaZulu",
					AwayScore = "3",
					HomeScore = "2",
				},
				new MatchResult
				{
					Id = 5,
					HomeTeam = "Cape Town City",
					AwayTeam = "Kaizer Chiefs",
					AwayScore = "0",
					HomeScore = "3",
				}

				);

			modelBuilder.Entity<Post>().HasData(
				new Post
				{
					Id = 1,
					Username = "Test",
					Comment = "Test",
				},
				new Post
				{
					Id = 2,
					Username = "Test1",
					Comment = "Sed ut perspiciatis unde omnis iste",
				},
				new Post
				{
					Id = 3,
					Username = "John",
					Comment = "Sed ut perspiciatis unde omnis iste",
				},
				new Post
				{
					Id = 4,
					Username = "Jane",
					Comment = "Sed ut perspiciatis unde omnis iste",
				}

				);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseMySQL("Server=localhost;Database=KCFanClubDB;User=root;Password=;");
			}
		}


	}
}
