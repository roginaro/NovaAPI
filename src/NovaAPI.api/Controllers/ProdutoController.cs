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

        // Sugestão: Se é um get da controller produtos, não precisaria de um nome para a rota.
        // A api ficará mais limpa e intuitiva.
        [HttpGet(Name = "produto")]
        public IEnumerable<string> Get()
        {
            // Num caso real, não é aconselhável a API atacar diretamente o banco de dados.
            // API -> Services -> Repositories -> Banco de Dados
            return _produto.GetAll();
        }

    }
}
