﻿using System;
using VideoClub.Domain.Entities;

namespace VideoClub.Domain.Services
{
	public interface IMovieRentalService
	{
		(MovieRental Rental, Movie Movie) RentMovie(Customer customer, Movie movie, DateTime rentalDate);
		(MovieRental Rental, Movie Movie) ReturnMovie(Customer customer, Movie movie, DateTime rentalDate);
	}

	public class MovieRentalService : IMovieRentalService
	{
		public (MovieRental Rental, Movie Movie) RentMovie(Customer customer, Movie movie, DateTime rentalDate)
		{
			movie.Rent();
			var rental = customer.RentMovie(movie.Id, rentalDate,movie.Price);

			return (rental, movie);
		}

		public (MovieRental Rental, Movie Movie) ReturnMovie(Customer customer, Movie movie, DateTime rentalDate)
		{
			movie.Rent();
			var rental = customer.ReturnMovie(movie.Id, rentalDate);

			return (rental, movie);
		}
	}
}
