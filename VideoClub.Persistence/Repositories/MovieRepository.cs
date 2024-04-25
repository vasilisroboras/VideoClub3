using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoClub.Application.Dependencies;
using VideoClub.Domain.Entities;

namespace VideoClub.Persistence.Repositories
{
	public class MovieRepository : IMovieRepository
	{
		private readonly VideoClubDbContext _dbContext;

		public MovieRepository(VideoClubDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Movie> AddMovie(Movie movie, List<int> genreIds)
		{
			await _dbContext.Movies.AddAsync(movie);
			await _dbContext.SaveChangesAsync();

			//foreach (var genreId in genreIds)

			//{
			//	var movieGenre = new MovieGenre
			//	{
			//		MovieId = movie.Id,
			//		GenreId = genreId
			//	};

			//	_dbContext.MovieGenres.Add(movieGenre);
			//}

			await _dbContext.SaveChangesAsync();
			return movie;
		}

		public async Task<List<Movie>> GetAllMoviesAsync()
		{
			return await _dbContext.Movies.ToListAsync();
		}

		public async Task<Movie> GetMovieByIdAsync(int id)
		{
			return await _dbContext.Movies.FindAsync(id);
		}

		public async Task<Movie> GetMovieByTitleAsync(string title)
		{
			return await _dbContext.Movies.Include(c => c.Ratings).FirstOrDefaultAsync(m => m.Title == title);
		}

		public async Task<Movie> UpdateMovie(Movie movie)
		{
			var existingMovie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);

			if (existingMovie == null)
			{
				return null;
			}

			// TODO: this needs to work
			//existingMovie.Title = movie.Title;
			//existingMovie.Description = movie.Description;
			//existingMovie.MovieGenres = movie.MovieGenres;
			//existingMovie.IsAvailable = movie.IsAvailable;
			//existingMovie.Stock = movie.Stock;
			//existingMovie.ReleaseDate = movie.ReleaseDate;
			//existingMovie.Rentals = movie.Rentals;

			await _dbContext.SaveChangesAsync();
			return existingMovie;
		}
	}
}