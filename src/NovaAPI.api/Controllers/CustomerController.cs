using Microsoft.AspNetCore.Mvc;
using NovaAPI.Api.ViewModels;
using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;
using NovaAPI.Services.Interfaces.Materials;
using Swashbuckle.AspNetCore.Annotations;

namespace NovaAPI.Api.Controllers
{
    [Route("api/customer")]

    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Recupera todos clientes", Description = "Retorna todos os clientes cadastrados")]
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _customerService.GetAll();
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Recupera o cliente pelo id", Description = "Recupera o cliente pelo id")]
        public async Task<ActionResult<CustomerViewModel>> GetCostumer(int id)
        {
            var customer = await _customerService.Get(id);
            if (!customer.Success)
            {
                return NotFound(customer.Message);
            }
            return Ok(new CustomerViewModel()
            {
                CustomerId = customer.Data.CustomerId,
                Address = customer.Data.Address,
                Document = customer.Data.Document,
                Email = customer.Data.Email,
                Name = customer.Data.Name,
                Phone = customer.Data.Phone
            });
        }

        [HttpPost()]
        public async Task<ActionResult<ServiceOutput<Customer>>> Add([FromBody] CustomerViewModel customer)
        {
            var serviceOutput = await _customerService.Add(new Customer()
            {
                CustomerId = customer.CustomerId,
                Address = customer.Address,
                Document = customer.Document,
                Email = customer.Email,
                Name = customer.Name,
                Phone = customer.Phone
            });
            if (!serviceOutput.Success)
            {
                return BadRequest(serviceOutput.Message);
            }
            return Ok(serviceOutput);
        }
        [HttpPut()]
        public async Task<ActionResult<ServiceOutput<Customer>>> Update([FromBody] CustomerViewModel customer)
        {
            var serviceOutput = await _customerService.Update(new Customer()
            {
                CustomerId = customer.CustomerId,
                Address = customer.Address,
                Document = customer.Document,
                Email = customer.Email,
                Name = customer.Name,
                Phone = customer.Phone
            });
            if (!serviceOutput.Success)
            {
                return BadRequest(serviceOutput.Message);
            }
            return Ok(serviceOutput);
        }
    }
}
