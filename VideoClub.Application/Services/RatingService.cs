using System;
using System.Threading;
using System.Threading.Tasks;
using VideoClub.Application.Dependencies;
using VideoClub.Domain.Services;

namespace VideoClub.Application.Services
{
    public class RatingService
    {
        private readonly IMovieRepository _movieRepository;
        public readonly IRatingRepository _ratingRepository;
        public readonly ICustomerRepository _customerRepository;
        public readonly IMovieRateService _movieRateService;

        public RatingService(IMovieRateService movieRateService, IMovieRepository movieRepository, ICustomerRepository customerRepository, IRatingRepository ratingRepository)
        {
            _movieRepository = movieRepository;
            _customerRepository = customerRepository;
            _ratingRepository = ratingRepository;
            _movieRateService = movieRateService;
        }

        public async Task<string> RateMovie(string movieTitle, string customerName, double rate, DateTime rateDate, CancellationToken token)
        {
            var customer = await _customerRepository.GetCustomerByNameAsync(customerName, token);
            if (customer == null)
                return "Customer not found";

            var movie = await _movieRepository.GetMovieByTitleAsync(movieTitle);
            if (movie == null)
                return "Movie not found";

            var movieRatingResult = _movieRateService.RateMovie(customer, movie, rate, rateDate);

            await _ratingRepository.UpdateRating(movieRatingResult);

            return $"Movie rated successfully. Your rating was {movieRatingResult.Rate}";
        }
    }
}