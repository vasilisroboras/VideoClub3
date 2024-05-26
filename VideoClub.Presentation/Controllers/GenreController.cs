using Microsoft.AspNetCore.Mvc;
using System;
using VideoClub.Application.Services;
using System.Collections.Generic;
using VideoClub.Domain.Entities;
using System.Threading.Tasks;
using AutoMapper;

namespace VideoClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        private readonly IMapper _genreMapper;

        public GenreController(IGenreService GenreService, IMapper genreMapper)
        {
            _genreService = GenreService;
            _genreMapper = genreMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            try
            {
                var genres =await _genreService.GetAllGenresAsync();
                return Ok(genres);
            }
            catch (Exception ex)
            {
            
            return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            try
            {
                var Genres = await  _genreService.GetGenreByIdAsync(id);
                return Ok(Genres);
            }
            catch (Exception ex)
            {
            
            return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async  Task<IActionResult>  AddGenre([FromBody] GenreDTO genreDto)
        {

            var genre = _genreMapper.Map<Genre>(genreDto);
            if (genre == null)
            {
                return BadRequest("Invalid Genre data.");
            }

            var addedGenre = await _genreService.AddGenre(genre);

           if (addedGenre != null)
            {
                
                return CreatedAtAction("GetGenreById", new { id = addedGenre.Id }, addedGenre);
            }
            else
            {
                
                return StatusCode(500, "Failed to add Genre.");
            }
        }

    }
}
