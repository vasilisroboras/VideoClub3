using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Common;
using VideoClub.Domain.Exceptions;

namespace VideoClub.Domain.Entities
{
    public class Customer : IEntity
    {
        private readonly List<MovieRental> _rentals;

        public int Id { get; }
        public string Name { get; }
        public IReadOnlyCollection<MovieRental> Rentals => _rentals.AsReadOnly();

        public Customer()
        {
            _rentals = new List<MovieRental>();
        }

        internal Customer(int id, string name, MovieRental[] rentals = null)
        {
            Id = id;
            Name = name;
            _rentals = rentals?.ToList() ?? new List<MovieRental>(0);
        }

        public static Customer CreateCustomer(int id, string name)
        {
            return new Customer(id, name, Array.Empty<MovieRental>());
        }

        public MovieRental RentMovie(Movie movie, DateTime rentalDate)
        {
            if (!DateTime.TryParse(rentalDate.ToString(), out DateTime date))
            {
                throw new Exception("Invalid rental date");
            }

            if (movie.Id <= 0)
            {
                throw new Exception("Invalid Movie Id");
            }

            if (_rentals.Exists(x => x.MovieId == movie.Id))
                throw new InvalidRentalException($"You are already renting this movie, id {movie.Id}");

            movie.Rent();
            _rentals.Add(new MovieRental(Id, movie.Id, rentalDate, movie.Price));

            return new MovieRental(Id, movie.Id, rentalDate, movie.Price);
        }

        public MovieRental ReturnMovie(Movie movie, DateTime returnDate)
        {
            if (!DateTime.TryParse(returnDate.ToString(), out DateTime date))
            {
                throw new Exception("Invalid return date");
            }

            if (movie.Id <= 0)
            {
                throw new Exception("Invalid Rental Id");
            }

            var rentalToBeReturned = _rentals.Find(x => x.MovieId == movie.Id);

            if (rentalToBeReturned == null)
                throw new Exception("Rental could not be found");

            if (rentalToBeReturned.ReturnedDate != default)
                throw new Exception("Movie has already been returned");

            movie.Return();
            rentalToBeReturned.CalculatePriceAndReturnDate(returnDate);

            return rentalToBeReturned;
        }
    }
}