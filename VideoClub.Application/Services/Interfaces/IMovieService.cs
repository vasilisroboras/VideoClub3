using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VideoClub.Domain.Entities;

namespace VideoClub.Application.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Movie> GetMovieByTitleAsync(string title);
        Task<Movie> AddMovie(Movie movie, List<int> genreIds);
        Task<string> RentMovie(string movieTitle, string customerName, DateTime rentalDate, CancellationToken token);
        Task<string> ReturnMovie(string movieTitle, string customerName, DateTime returnRentalDate, CancellationToken token);
    }
}
