using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoClub.Application.Dependencies;
using VideoClub.Domain.Entities;

namespace VideoClub.Persistence.Repositories
{
	public class GenreRepository : IGenreRepository
	{
		private readonly VideoClubDbContext _dbContext;

		public GenreRepository(VideoClubDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<Genre> AddGenre(Genre genre)
		{
			await _dbContext.Genres.AddAsync(genre);
			await _dbContext.SaveChangesAsync();
			return genre;
		}

		public async Task<List<Genre>> GetAllGenresAsync()
		{
			return await _dbContext.Genres.ToListAsync();
		}

		public async Task<Genre> GetGenreByIdAsync(int id)
		{
			return await _dbContext.Genres.FindAsync(id);
		}
	}
}