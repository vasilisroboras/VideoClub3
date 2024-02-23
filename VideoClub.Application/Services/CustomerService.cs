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

        public async Task<List<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            return await _customerRepository.GetAllCustomersAsync(cancellationToken);
        }

        public async Task<Customer> GetCustomerByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerByNameAsync(name, cancellationToken);
        }

        public async Task<Customer> AddCustomer(Customer customer, CancellationToken cancellationToken)
        {
            return await _customerRepository.AddCustomer(customer,cancellationToken);
        }
    }
}