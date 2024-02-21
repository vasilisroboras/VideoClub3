using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using VideoClub.Application.Services;

namespace VideoClub.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReturnRentalController : ControllerBase
	{
		private readonly MovieService _movieService;

		public ReturnRentalController(MovieService movieService)
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
