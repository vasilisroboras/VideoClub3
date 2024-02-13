using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using VideoClub.Application.Dependencies;
using VideoClub.Application.Services.Interfaces;
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

		public readonly ITransactionService _iTransactionService;

		public MovieService(ITransactionService iTransactionService,IMovieRepository movieRepository, IRentalRepository rentalRepository, ICustomerRepository customerRepository, IMovieRentalService movieRentalService)
		{
			_movieRepository = movieRepository;
			_rentalRepository = rentalRepository;
			_customerRepository = customerRepository;
			_movieRentalService = movieRentalService;
			_iTransactionService = iTransactionService;
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

		public async  Task<string> RentMovie(string movieTitle, string customerName, DateTime rentalDate, CancellationToken token)
		{
			var customer = await _customerRepository.GetCustomerByNameAsync(customerName, token);
			if (customer == null)
				return "Customer not found";

			var movie = await _movieRepository.GetMovieByTitleAsync(movieTitle);
			if (movie == null)
				return "Movie not found";

			var movieReltanResult = _movieRentalService.RentMovie(customer, movie, rentalDate);
			// TODO: make this transactional!
			 try
            {
                await _iTransactionService.ExecuteInTransactionAsync(async () =>
                {
                    await _movieRepository.UpdateMovie(movieReltanResult.Movie);
                    await _rentalRepository.AddRental(movieReltanResult.Rental);
                });

                return "Movie rented successfully";
            }
			 catch (Exception ex)
            {
                // Log or handle the exception
                return $"Failed to rent the movie: {ex.Message}";
            }

		}

		// public async  Task<string> ReturnMovie(string customerName,int RentalId, DateTime ReturnDate, CancellationToken token)
		// {
		// 	var customer = await _customerRepository.GetCustomerByNameAsync(customerName, token);
		// 	if (customer == null)
		// 		return "Customer not found";

		// 	var movie = await _movieRepository.GetMovieByTitleAsync(movieTitle);
		// 	if (movie == null)
		// 		return "Movie not found";

		// 	var movieReltanResult = _movieRentalService.RentMovie(customer, movie, rentalDate);
		// 	// TODO: make this transactional!
		// 	 try
        //     {
        //         await _iTransactionService.ExecuteInTransactionAsync(async () =>
        //         {
        //             await _movieRepository.UpdateMovie(movieReltanResult.Movie);
        //             await _rentalRepository.AddRental(movieReltanResult.Rental);
        //         });

        //         return "Movie rented successfully";
        //     }
		// 	 catch (Exception ex)
        //     {
        //         // Log or handle the exception
        //         return $"Failed to rent the movie: {ex.Message}";
        //     }

		// }
	}
}