using System.Collections.Generic;
using System.Threading.Tasks;
using VideoClub.Application.Dependencies;
using VideoClub.Domain.Entities;

namespace VideoClub.Application.Services
{
	public class GenreService: IGenreService
    {
        private readonly IGenreRepository _GenreRepository;

        public GenreService(IGenreRepository GenreRepository)
        {
            _GenreRepository = GenreRepository;
        }

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            return await _GenreRepository.GetAllGenresAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _GenreRepository.GetGenreByIdAsync(id);
        }

        public async Task<Genre> AddGenre(Genre genre)
        {
            return await _GenreRepository.AddGenre(genre);
        }        
    }
}