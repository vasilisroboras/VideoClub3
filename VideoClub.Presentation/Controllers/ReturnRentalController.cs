using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using VideoClub.Application.Services;
using VideoClub.Application.Services.Interfaces;

namespace VideoClub.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReturnRentalController : ControllerBase
	{
		private readonly IMovieService _movieService;

		public ReturnRentalController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		[HttpPost]
		public async Task<IActionResult> ReturnMovie(string movieTitle, string customerName, DateTime returnRentalDate, CancellationToken token)
		{
			try
			{
				var movieRented = await _movieService.ReturnMovie( movieTitle, customerName, returnRentalDate, token);
				return Ok(movieRented);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

	}
}
