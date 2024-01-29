using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VideoClub.Application.Dependencies;
using VideoClub.Domain.Entities;

namespace VideoClub.Application.Services
{
	public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task<Customer> GetCustomerByNameAsync(string name, CancellationToken token)
        {
            return await _customerRepository.GetCustomerByNameAsync(name, token);
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            return await _customerRepository.AddCustomer(customer);
        }
    }
}