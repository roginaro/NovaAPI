using Microsoft.AspNetCore.Mvc;
using NovaAPI.Api.ViewModels;
using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;
using NovaAPI.Services.Interfaces.Materials;
using NovaAPI.Services.Services;

namespace NovaAPI.api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productServiceInstance)
        {
            _productService = productServiceInstance;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductViewModel>> GetProduct(int id)
        {
            var customerOutput = await _productService.Get(id);
            if (!customerOutput.Success)
            {
                return NotFound(customerOutput.Message);
            }
            return Ok(new ProductViewModel()
            {
                Name = customerOutput.Data.Name,
                Description = customerOutput.Data.Description,
                Price = customerOutput.Data.Price,
                Image = customerOutput.Data.Image,
                ProductId = customerOutput.Data.ProductId,
            });
        }

        [HttpPost()]
        public async Task<ActionResult<ServiceOutput<Product>>> AddProduct([FromBody] ProductViewModel product)
        {
            var serviceOutput = await _productService.Add(new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Image = product.Image
            });
            if (!serviceOutput.Success)
            {
                return BadRequest(serviceOutput.Message);
            }
            return Ok(serviceOutput);
        }

        [HttpPut()]
        public async Task<ActionResult<ServiceOutput<Product>>> UpdateProduct([FromBody] ProductViewModel product)
        {
            var serviceOutput = await _productService.Update(new Product()
            {
                Name= product.Name,
                Description = product.Description,
                Price = product.Price,
                Image = product.Image,
            });
            if (!serviceOutput.Success)
            {
                return BadRequest(serviceOutput.Message);
            }
            return Ok(serviceOutput);
        }
    }
}
