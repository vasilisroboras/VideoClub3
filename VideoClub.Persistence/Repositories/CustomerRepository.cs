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

		public async Task<Customer> AddCustomer(Customer customer1,CancellationToken cancellationToken = default)
		{
			var x = Customer.CreateCustomer(customer1.Id, customer1.Name);
			await _dbContext.Customers.AddAsync(x);
			await _dbContext.SaveChangesAsync();
			return x;
		}

		public async Task<List<Customer>> GetAllCustomersAsync()
		{
			return await _dbContext.Customers.ToListAsync();
		}

		public async Task<Customer> GetCustomerByNameAsync(string name, CancellationToken token)
		{
			return await _dbContext.Customers.Include(c => c.Rentals).FirstOrDefaultAsync(m => m.Name == name, token);
		}
    }
}