using System;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Common;

namespace VideoClub.Domain.Entities
{
	public class MovieRental : IEntity
	{
		public int Id { get; }
		public int CustomerId { get; }
		public int MovieId { get; }
		public DateTime RentalDate { get; }

		public MovieRental() { }

		internal MovieRental(int id, int customerId, int movieId, DateTime rentalDate)
		{
			Id = id;
			CustomerId = customerId;
			MovieId = movieId;
			RentalDate = rentalDate;
		}

		internal MovieRental(int customerId, int movieId, DateTime rentalDate)
			: this(0, customerId, movieId, rentalDate) { }
	}
}