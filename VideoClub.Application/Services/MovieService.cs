using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using VideoClub.Application.Dependencies;
using VideoClub.Domain.Entities;
using VideoClub.Domain.Services;

namespace VideoClub.Application.Services
{
	public class MovieService
	{
		private readonly IMovieRepository _movieRepository;
		public readonly IRentalRepository _rentalRepository;
		public readonly ICustomerRepository _customerRepository;
		public readonly IMovieRentalService _movieRentalService;

		public MovieService(IMovieRepository movieRepository, IRentalRepository rentalRepository, ICustomerRepository customerRepository, IMovieRentalService movieRentalService)
		{
			_movieRepository = movieRepository;
			_rentalRepository = rentalRepository;
			_customerRepository = customerRepository;
			_movieRentalService = movieRentalService;
		}

		public async Task<List<Movie>> GetAllMoviesAsync()
		{
			return await _movieRepository.GetAllMoviesAsync();
		}

		public async Task<Movie> GetMovieByIdAsync(int id)
		{
			return await _movieRepository.GetMovieByIdAsync(id);
		}

		public async Task<Movie> GetMovieByTiteAsync(string title)
		{
			return await _movieRepository.GetMovieByTitleAsync(title);
		}

		public async Task<Movie> AddMovie(Movie movie, List<int> genreIds)
		{
			return await _movieRepository.AddMovie(movie, genreIds);
		}

		public async Task<string> RentMovie(string movieTitle, string customerName, DateTime rentalDate, CancellationToken token)
		{
			var customer = await _customerRepository.GetCustomerByNameAsync(customerName, token);
			if (customer == null)
				return "Customer not found";

			var movie = await _movieRepository.GetMovieByTitleAsync(movieTitle);
			if (movie == null)
				return "Movie not found";

			var movieReltanResult = _movieRentalService.RentMovie(customer, movie, rentalDate);
			// TODO: make this transactional!
			using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				try
				{
					await _movieRepository.UpdateMovie(movieReltanResult.Movie);
					await _rentalRepository.AddRental(movieReltanResult.Rental);

					scope.Complete();
				}
				catch (TransactionAbortedException ex)
				{
					return "TransactionAbortedException Message: {0}" + ex.Message;
				}
				finally
				{
					scope.Dispose();
				}
			}

			return "Movie rented succesful";

		}
	}
}