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

		public static Customer CreateCustomer(int id, string name, int age)
		{
			return new Customer(id, name, Array.Empty<MovieRental>());
		}

		public MovieRental RentMovie(int movieId, DateTime rentalDate)
		{
			if (_rentals.Exists(x => x.MovieId == movieId))
				throw new InvalidRentalException($"Movie with id {movieId} is already rented by customer with id {Id}");

			_rentals.Add(new MovieRental(Id, movieId, rentalDate));

			return new MovieRental(Id, movieId, rentalDate);
		}

		public void ReturnMovie(int rentalId, DateTime returnDate)
		{
			throw new NotImplementedException();
		}
	}
}