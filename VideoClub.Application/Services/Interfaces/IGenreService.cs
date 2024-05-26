using System.Collections.Generic;
using System.Threading.Tasks;
using VideoClub.Domain.Entities;

namespace VideoClub.Application.Services
{
    public interface IGenreService
    {
        Task<List<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task<Genre> AddGenre(Genre genre);
    }
}
