using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaAPI.repositories.Interfaces
{
    // Procure sempre dar nomes mais intuitivos para as interfaces.
    // Por exemplo, se você está na camada de repositories, poderia ser IProdutoRepository.
    // Uma outra sugestão: Utilize sempre nomes em inglês, por exemplo IProductRepository.
    // Por que disseo? Porque se você for trabalhar em um projeto com pessoas de outros países, você já estará acostumado
    // Um outro ponto é que vc declarou IProduto (PT) e o nome do método é GetAll, então seria melhor IProductRepository e GetAll OU IProduto e ObterTodos.
    public interface IProduto
    {
        List<string> GetAll();
    }
}
