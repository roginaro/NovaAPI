using NovaAPI.repositories.Interfaces;
using NovaAPI.repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaAPI.repositories.Repositories
{
    public class ProdutoRepository : IProduto
    {
        private static readonly string[] produtos = new[]
        {
            "caixa ", "fosforo", "caneta", "peteca", "pistola", "bandeira"
        };
        //
        public List<string> GetAll()
        {
            List<string> list = produtos.ToList();
            return list;
        }
    }
}
