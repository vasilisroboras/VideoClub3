using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VideoClub.Domain.Entities;

namespace VideoClub.Application.Dependencies
{
	public interface ICustomerRepository
	{
		Task<Customer> AddCustomer(Customer customer,CancellationToken cancellationToken);
		Task<List<Customer>> GetAllCustomersAsync();
		Task<Customer> GetCustomerByNameAsync(string name, CancellationToken token);
	}

	public interface IGenreRepository
	{
		Task<Genre> AddGenre(Genre genre);
		Task<List<Genre>> GetAllGenresAsync();
		Task<Genre> GetGenreByIdAsync(int id);
	}

	public interface IMovieRepository
	{
		Task<Movie> AddMovie(Movie movie, List<int> genreIds);
		Task<List<Movie>> GetAllMoviesAsync();
		Task<Movie> GetMovieByIdAsync(int id);
		Task<Movie> GetMovieByTitleAsync(string title);
		Task<Movie> UpdateMovie(Movie movie);
	}

	public interface IRentalRepository
	{
		Task<MovieRental> AddRental(MovieRental rental);
	}

	public interface IRatingRepository
	{
		Task<Rating> UpdateRating(Rating rating);
	}
}
