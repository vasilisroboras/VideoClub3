using System;
using System.Threading.Tasks;
namespace VideoClub.Application.Services.Interfaces
{
    public interface ITransactionService
    {
        Task ExecuteInTransactionAsync(Func<Task> action);
    }
}
