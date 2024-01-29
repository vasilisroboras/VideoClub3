using System.Threading.Tasks;
using VideoClub.Application.Dependencies;
using VideoClub.Domain.Entities;

namespace VideoClub.Persistence.Repositories
{
	public class RentalRepository : IRentalRepository
	{
		private readonly VideoClubDbContext _dbContext;

		public RentalRepository(VideoClubDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<MovieRental> AddRental(MovieRental rental)
		{

			_dbContext.Rentals.Add(rental);
			await _dbContext.SaveChangesAsync();

			return rental;
		}
	}
}