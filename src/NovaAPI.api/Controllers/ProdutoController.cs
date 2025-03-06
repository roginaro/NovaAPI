using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovaAPI.business.Models;
using NovaAPI.services.Interfaces.Materials;

namespace NovaAPI.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProdutoController(IProductService productServiceInstance)
        {
            _productService = productServiceInstance;
        }

        [HttpGet(Name = "Productos")]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productService.GetProducts();
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<Product> GetProduct(int id)
        {
            return await _productService.GetProduct(id);
        }
    }
}
