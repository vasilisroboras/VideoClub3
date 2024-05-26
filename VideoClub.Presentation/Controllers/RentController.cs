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
	public class RentController : ControllerBase
	{
		private readonly IMovieService _movieService;

		public RentController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		[HttpPost]
		public async Task<IActionResult> RentAMovie(string movieTitle, string customerName, DateTime rentalDate, CancellationToken token)
		{
			try
			{
				var movieRented = await _movieService.RentMovie( movieTitle, customerName, rentalDate, token);
				return Ok(movieRented);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

	}
}
