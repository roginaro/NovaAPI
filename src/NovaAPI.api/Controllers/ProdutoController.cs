using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovaAPI.repositories.Interfaces;
using NovaAPI.repositories.Repositories;

namespace NovaAPI.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProduto _produto;

        public ProdutoController(IProduto produto)
        {
            _produto = produto;
        }

        [HttpGet(Name = "produto")]
        public IEnumerable<string> Get()
        {
            return _produto.GetAll();
        }

    }
}
