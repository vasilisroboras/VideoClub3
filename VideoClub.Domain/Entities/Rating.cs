using CleanArchitecture.Domain.Common;
using System;

namespace VideoClub.Domain.Entities
{
    public class Rating : IEntity
    {
        public int Id { get; }
        public int CustomerId { get; }
        public int MovieId { get; }
        public double Rate { get; }
        public DateTime RatingDate { get; }
        public Rating()
        {

        }

        internal Rating(int id, int customerId, int movieId, double rate, DateTime ratingDate)
        {
            Id = id;
            CustomerId = customerId;
            MovieId = movieId;
            Rate = rate;
            RatingDate = ratingDate;
        }

        internal Rating(int customerId, int movieId, double rate, DateTime ratingDate)
            : this(0, customerId, movieId, rate, ratingDate) { }
    }
}