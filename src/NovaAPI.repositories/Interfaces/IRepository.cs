using NovaAPI.Entities.Base;

namespace NovaAPI.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<RepositoryOutput<T>> Add(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<RepositoryOutput<T>> GetById(int id);

        Task<RepositoryOutput<T>> Remove(int id);

        Task<RepositoryOutput<T>> Update(T entity);
    }
}
