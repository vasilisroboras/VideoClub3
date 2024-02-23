using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using VideoClub.Application.Services;

namespace VideoClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly RatingService _ratingService;

        public RatingController(RatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        public async Task<IActionResult> RateMovie(string movieTitle, string customerName, double rating, DateTime ratingDate, CancellationToken token)
        {
            try
            {
                var movieRented = await _ratingService.RateMovie(movieTitle, customerName, rating, ratingDate, token);
                return Ok(movieRented);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
