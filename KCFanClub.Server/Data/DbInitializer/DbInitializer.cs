using Microsoft.EntityFrameworkCore;

namespace KCFanClub.Server.Data.DbInitializer
{
	public class DbInitializer : IDbInitializer
	{
		private readonly ApplicationDbContext _db;

		public DbInitializer(ApplicationDbContext db)
		{
			_db = db;
		}
		public void Initialize()
		{
			//apply migrations if they are not applied
			try
			{
				if (_db.Database.GetPendingMigrations().Count() > 0)
				{
					_db.Database.Migrate();
				}
			}
			catch (Exception)
			{

				throw;
			}


		}
	}
}
