using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VideoClub.Domain.Entities;

namespace VideoClub.Application.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByNameAsync(string name, CancellationToken token);
        Task<Customer> AddCustomer(Customer customer, CancellationToken cancellationToken);
    }
}