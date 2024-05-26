using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using VideoClub.Application.Services;
using VideoClub.Application.Services.Interfaces;
using VideoClub.Domain.Entities;

namespace VideoClub.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RatingController : ControllerBase
	{
		private readonly IRatingService _ratingService;

		public RatingController(IRatingService ratingService)
		{
			_ratingService = ratingService;
		}

		[HttpPost]
		public async Task<IActionResult> RateMovie(string movieTitle, string customerName,double Rating, DateTime ratingDate, CancellationToken token)
		{
			try
			{
				var movieRented = await _ratingService.RateMovie( movieTitle, customerName,Rating, ratingDate, token);
				return Ok(movieRented);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

	}
}
