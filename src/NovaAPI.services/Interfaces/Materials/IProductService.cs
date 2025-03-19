using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;

namespace NovaAPI.Services.Interfaces.Materials
{
    public interface IProductService : IService<Product>
    {   
        Task<ServiceOutput<Product>> Update(Product product);
    }
   
}
