using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoClub.Domain.Exceptions;

namespace VideoClub.Domain.Entities
{
    public class Movie : IEntity
    {
        private readonly List<Genre> _genres;

        private readonly List<Rating> _ratings;
        public IReadOnlyCollection<Rating> Ratings => _ratings.AsReadOnly();

        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public ICollection<Genre> Genres => _genres.AsReadOnly();
        public DateTime ReleaseDate { get; }
        public int Stock { get; private set; }
        public double AverageRating { get; private set; }

        public int Price
        {
            get
            {
                if (ReleaseDate.Year < 1990)
                {
                    return 1;
                }
                else if (ReleaseDate.Year >= 1990 && ReleaseDate.Year < 2000)
                {
                    return 3;
                }
                else
                {
                    return 5;
                }
            }
            private set { }
        }

        public bool IsAvailable => Stock == 0;

        public Movie()
        {
            _genres = new List<Genre>();
            _ratings = new List<Rating>();
        }

        internal Movie(int id, string title, string description, Genre[] movieGenres, DateTime releaseDate, int stock)
        {
            Id = id;
            Title = title;
            Description = description;
            ReleaseDate = releaseDate;
            Stock = stock;
            Price = 0;
            _ratings = _ratings?.ToList() ?? new List<Rating>(0);

            _genres = movieGenres?.ToList() ?? new List<Genre>(0);
        }

        internal void Rent()
        {
            if (IsAvailable)
                throw new MovieUnavailableException($"Movie with id {Id} is not available for rent!");

            Stock -= 1;
        }

        internal void Return()
        {
            Stock += 1;
        }

        internal Rating AddRating(int customerId, int movieId, double rate, DateTime ratingDate)
        {
            var ratedMovie = new Rating(customerId, movieId, rate, ratingDate);
            _ratings.Add(ratedMovie);
            CalculateAverageRating();
            return ratedMovie;
        }

        private void CalculateAverageRating()
        {
            if (_ratings.Count == 0)
            {
                AverageRating = 0;
            }
            else
            {
                double totalRating = _ratings.Sum(r => r.Rate);
                AverageRating = (double)totalRating / _ratings.Count;
            }
        }
    }
}