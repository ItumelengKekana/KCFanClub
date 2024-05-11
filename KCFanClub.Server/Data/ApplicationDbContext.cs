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
				}
			);
		}
	}
}
