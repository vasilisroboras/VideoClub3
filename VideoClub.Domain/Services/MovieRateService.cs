using System;
using VideoClub.Domain.Entities;

namespace VideoClub.Domain.Services
{
    public interface IMovieRateService
    {
        Rating RateMovie(Customer customer, Movie movie, double rate, DateTime rateDate);
    }

    public class MovieRateService : IMovieRateService
    {
        public Rating RateMovie(Customer customer, Movie movie, double rate, DateTime rateDate)
        {
            var ratedMovie = movie.AddRating(customer.Id, movie.Id, rate, rateDate);

            return ratedMovie;
        }
    }
}
