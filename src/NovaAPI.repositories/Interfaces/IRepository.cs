using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaAPI.Repositories.Interfaces
{
    public interface IRepository<T> 
    {

        Task<RepositoryOutput<T>> Add(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<RepositoryOutput<T>> GetById(int id);

        Task<RepositoryOutput<T>> Remove(int id);
    }
}
