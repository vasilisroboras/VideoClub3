using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VideoClub.Application.Dependencies;
using VideoClub.Domain.Entities;

namespace VideoClub.Persistence.Repositories
{
	public class RatingRepository : IRatingRepository
	{
		private readonly VideoClubDbContext _dbContext;

		public RatingRepository(VideoClubDbContext dbContext)
		{
			_dbContext = dbContext;
		}       

         public async Task<Rating> UpdateRating(Rating rating)
        {
			await _dbContext.Ratings.AddAsync(rating);
           await _dbContext.SaveChangesAsync();

			return rating;
        }
    }
}