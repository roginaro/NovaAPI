using Microsoft.EntityFrameworkCore;
using NovaAPI.Entities.Base;
using NovaAPI.Repositories.Contexts;
using NovaAPI.Repositories.Interfaces;

namespace NovaAPI.Repositories.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly NovaAPIDbContext _context;

        public BaseRepository(NovaAPIDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<RepositoryOutput<T>> Add(T entity)
        {
            if (entity == null)
            {
                return new RepositoryOutput<T>() { Success = false, Message = "Entity is null" };
            }
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new RepositoryOutput<T>() { Success = true, Message = "Add Success" };
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<RepositoryOutput<T>> GetById(int id)
        {

            if (id < 0)
            {
                return new RepositoryOutput<T>() { Success = false, Message = "id is null" };
            }
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return new RepositoryOutput<T>() { Success = false, Message = "Entity not found" };
            }
            return new RepositoryOutput<T>() { Success = true, Message = "Add Success", Data = entity };

        }

        public async Task<RepositoryOutput<T>> Remove(int id)
        {
            if (id < 0)
            {
                return new RepositoryOutput<T>() { Success = false, Message = "Id invalid" };
            }
            var entity = await this.GetById(id);
            if (!entity.Success)
            {
                return new RepositoryOutput<T>() { Success = false, Message = "Entity not found" };
            }
            _dbSet.Remove(entity.Data);
            var returnSavechanges = await _context.SaveChangesAsync();

            if (returnSavechanges == 0)
            {
                return new RepositoryOutput<T>() { Success = false, Message = "Remove failed" };
            }
            return new RepositoryOutput<T>() { Success = true, Message = "Remove Success" };
        }

        public abstract Task<RepositoryOutput<T>> Update(T entity);

    }
}
