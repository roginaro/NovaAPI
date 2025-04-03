using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;

namespace NovaAPI.Services.Interfaces.Materials
{
    public interface ICustomerService : IService<Customer>
    {
        Task<ServiceOutput<Customer>> Update(Customer customer);
    }

}
