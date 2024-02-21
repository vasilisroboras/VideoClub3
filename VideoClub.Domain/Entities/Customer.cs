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

		public MovieRental RentMovie(int movieId, DateTime rentalDate,int price)
		{

			if (!DateTime.TryParse(rentalDate.ToString(), out DateTime date))
			{
				throw new Exception("Invalid rental date");
			}
			
			if( movieId <= 0){
				throw new Exception("Invalid Movie Id");
			}
			if (_rentals.Exists(x => x.MovieId == movieId))
				throw new InvalidRentalException($"You are already renting this movie,id {movieId}");

			_rentals.Add(new MovieRental(Id, movieId, rentalDate,price));

			return new MovieRental(Id, movieId, rentalDate,price);
		}

		public MovieRental ReturnMovie(int rentalId, DateTime returnDate)
		{
			if (!DateTime.TryParse(returnDate.ToString(), out DateTime date))
			{
				throw new Exception("Invalid return date");
			}
			
			if( rentalId <= 0){
				throw new Exception("Invalid Rental Id");
			}

			var rentalToBeReturned = _rentals.Find(x => x.MovieId == rentalId);			

			if (rentalToBeReturned == null)
				throw new Exception("Rental could not be found");

			if (rentalToBeReturned.ReturnedDate != default)			
				throw new Exception("Movie has already been returned");

			rentalToBeReturned.CalculatePriceAndReturnDate(returnDate);

			if(!DateTime.TryParse(rentalToBeReturned.ReturnedDate.ToString(), out DateTime dateReturned)){
				throw new Exception("Could not return Movie");
			}
			return rentalToBeReturned;
		}
	}
}