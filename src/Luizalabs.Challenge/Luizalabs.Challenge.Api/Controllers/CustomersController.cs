using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Luizalabs.Challenge.Contracts.v1.Requests;
using Luizalabs.Challenge.Contracts.v1.Responses;
using Luizalabs.Challenge.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Luizalabs.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomers _customers;
        private readonly IMapper _mapper;

        public CustomersController(
            ICustomers customers,
            IMapper mapper)
        {
            _customers = customers;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1)
        {
            var customers = await _customers.GetAllPerPage(page);
            var response = _mapper.Map<IEnumerable<CustomerResponse>>(customers);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerPost customerPost)
        {
            if (await _customers.ExistsEmail(customerPost.Email)) throw new Exception("E-mail ja cadastrado");

            var customer = customerPost.CreateDomain();
            await _customers.Insert(customer);

            return Ok(new Response<long>(customer.Id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]long id, CustomerPut customerPut)
        {
            var customer = await _customers.GetById(id);

            if (customer == null) throw new Exception("Cliente não encontrado");

            customerPut.UpdateDomain(customer);

            await _customers.Update(customer);

            return Ok(new Response<long>(customer.Id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            await _customers.RemoveById(id);

            return Ok(new Response<long>(id));
        }


    }
}