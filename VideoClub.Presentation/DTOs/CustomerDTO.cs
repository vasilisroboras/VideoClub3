using System.Collections.Generic;
using VideoClub.Domain.Entities;

public class CustomerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<MovieRental> Rentals { get; set; }
}
