using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;

namespace NovaAPI.Services.Interfaces.Materials
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<ServiceOutput<T>>Get(int id);
        Task<ServiceOutput<T>> Add(T entity);
        Task<ServiceOutput<T>> Delete(int id);
    }
   
}
