using System;
using System.Collections.Generic;
using VideoClub.Domain.Entities;

public class MovieDTO
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public ICollection<Genre> MovieGenres { get; set; }
	public DateTime ReleaseDate { get; set; }
	public int Stock { get; set; }
	public bool IsAvailable { get; set; }
	public List<int> GenreIds { get; set; }
	public int Price { get; set; }
	public ICollection<MovieRental> Rentals { get; set; }
}