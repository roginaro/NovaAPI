
using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;

namespace NovaAPI.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<RepositoryOutput<Customer>> GetByEntity(Customer custumer);
        Task<RepositoryOutput<Customer>> Update(Customer custumer);
    }
}
