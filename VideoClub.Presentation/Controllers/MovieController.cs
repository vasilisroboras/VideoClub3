using Microsoft.AspNetCore.Mvc;
using System;
using VideoClub.Application.Services;
using System.Collections.Generic;
using VideoClub.Domain.Entities;
using System.Threading.Tasks;
using AutoMapper;
using VideoClub.Application.Services.Interfaces;

namespace VideoClub.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		private readonly IMovieService _movieService;
		private readonly IMapper _movieMapper;



		public MovieController(IMovieService movieService, IMapper movieMapper)
		{
			_movieService = movieService;
			_movieMapper = movieMapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllMovies()
		{
			try
			{
				var movies = await _movieService.GetAllMoviesAsync();
				return Ok(movies);
			}
			catch (Exception ex)
			{

				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetMovieById(int id)
		{
			try
			{
				var movies = await _movieService.GetMovieByIdAsync(id);
				return Ok(movies);
			}
			catch (Exception ex)
			{

				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddMovie([FromBody] MovieDTO movieDTO)
		{
			if (movieDTO == null)
			{
				return BadRequest("Empty data");
			}
			
			var movieEntity = _movieMapper.Map<Movie>(movieDTO);

			var addedMovie = await _movieService.AddMovie(movieEntity, movieDTO.GenreIds);

			if (addedMovie != null)
			{
				return CreatedAtAction("GetMovieById", new { id = addedMovie.Id }, addedMovie);
			}
			else
			{
				return StatusCode(500, "Failed to add movie.");
			}
		}
	}
}
