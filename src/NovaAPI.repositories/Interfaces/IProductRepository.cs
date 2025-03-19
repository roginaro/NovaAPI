
using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;

namespace NovaAPI.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<RepositoryOutput<Product>> GetByEntity(Product product);
        Task<RepositoryOutput<Product>> Update(Product product);
    }
}
