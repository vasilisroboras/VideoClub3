using CleanArchitecture.Domain.Common;
using System;

namespace VideoClub.Domain.Entities
{
    public class MovieRental : IEntity
    {
        public int Id { get; }
        public int CustomerId { get; }
        public int MovieId { get; }
        public DateTime RentalDate { get; }
        public DateTime ShouldBeReturnedUntil { get; }
        public DateTime ReturnedDate { get; private set; }
        public int Price { get; private set; }

        public MovieRental() { }

        internal MovieRental(int customerId, int movieId, DateTime rentalDate, int price)
            : this(0, customerId, movieId, price, rentalDate) { }

        internal MovieRental(int id, int customerId, int movieId, int moviePrice, DateTime rentalDate)
        {
            Id = id;
            CustomerId = customerId;
            MovieId = movieId;
            RentalDate = rentalDate;
            Price = moviePrice;
            // TODO: move to a method, because this hides the business logic!
            ShouldBeReturnedUntil = rentalDate.AddDays(7);
        }

        internal void CalculatePriceAndReturnDate(DateTime returnDate)
        {
            if (returnDate > ShouldBeReturnedUntil)
            {
                TimeSpan lateDuration = DateTime.Now - ShouldBeReturnedUntil;
                int lateDays = (int)Math.Ceiling(lateDuration.TotalDays);
                // 1 euro extra per late day
                Price += lateDays;
            }

            ReturnedDate = returnDate;
        }
    }
}