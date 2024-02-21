using Microsoft.AspNetCore.Mvc;
using System;
using VideoClub.Application.Services;
using System.Collections.Generic;
using VideoClub.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;

namespace VideoClub.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly CustomerService _customerService;

		private readonly IMapper _customerMapper;

		public CustomerController(CustomerService customerService, IMapper customerMapper)
		{
			_customerService = customerService;			
			_customerMapper = customerMapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCustomers()
		{
			try
			{
				var customers = await _customerService.GetAllCustomersAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{

				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpGet("name")]
		public async Task<IActionResult> GetCustomerByName(string name, CancellationToken token)
		{
			try
			{
				 var customer = await _customerService.GetCustomerByNameAsync(name, token);
				return Ok(customer);
			}
			catch (Exception ex)
			{

				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customerDto, CancellationToken token)
		{
			var customer = _customerMapper.Map<Customer>(customerDto);
			if (customer == null)
			{
				return BadRequest("Invalid Customer data.");
			}

			var addedCustomer = await _customerService.AddCustomer(customer,token);

			if (addedCustomer != null)
			{
				return CreatedAtAction("GetCustomerByName", new { id = addedCustomer.Id }, addedCustomer);
			}
			else
			{
				return StatusCode(500, "Failed to add Customer.");
			}
		}
	}
}
