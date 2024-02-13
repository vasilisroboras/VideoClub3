using System;
using System.Threading.Tasks;
using System.Transactions;
using VideoClub.Application.Services.Interfaces;
public class TransactionService : ITransactionService
{
    public async Task ExecuteInTransactionAsync(Func<Task> action)
    {
        using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                await action();
                scope.Complete();
            }
            catch (TransactionAbortedException ex)
            {
                // Handle or log the exception as needed
                throw;
            }
        }
    }
}