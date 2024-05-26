using System;
using System.Threading;
using System.Threading.Tasks;

namespace VideoClub.Application.Services.Interfaces
{
    public interface IRatingService
    {
        Task<string> RateMovie(string movieTitle, string customerName, double rate, DateTime rateDate, CancellationToken token);
    }
}
