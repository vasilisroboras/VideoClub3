using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideoClub.Application.Dependencies;
using VideoClub.Domain.Entities;

namespace VideoClub.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly VideoClubDbContext _dbContext;

        public CustomerRepository(VideoClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> AddCustomer(Customer customer, CancellationToken cancellationToken = default)
        {
            await _dbContext.Customers.AddAsync(customer, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return customer;
        }

        public async Task<List<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Customers.ToListAsync(cancellationToken);
        }

        public async Task<Customer> GetCustomerByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Customers
                .Include(c => c.Rentals)
                .FirstOrDefaultAsync(m => m.Name == name, cancellationToken);
        }
    }
}