using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Contexts;
using NovaAPI.Repositories.Interfaces;

namespace NovaAPI.Repositories.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(NovaAPIDbContext context) : base(context)
        {
        }

        public async Task<RepositoryOutput<Customer>> GetByEntity(Customer custumer)
        {
            var entityReturn = await _dbSet.FindAsync(custumer.CustomerId);
            if (entityReturn == null)
            {
                return new RepositoryOutput<Customer>() { Success = false, Message = "Entity not found" };
            }
            return new RepositoryOutput<Customer>() { Success = true, Message = "Add Success", Data = entityReturn };

        }
        public override async Task<RepositoryOutput<Customer>> Update(Customer custumer)
        {
            var entityFromDB = await this.GetByEntity(custumer);
            if (!entityFromDB.Success)
            {
                return new RepositoryOutput<Customer>() { Success = false, Message = "Entity not found", Data = custumer };
            }
            var entityEntry = _dbSet.Update(entityFromDB.Data);
            var returnSavechanges = await _context.SaveChangesAsync();
            if (returnSavechanges == 0)
            {
                return new RepositoryOutput<Customer>() { Success = false, Message = "Update failed" };
            }
            return new RepositoryOutput<Customer>() { Success = true, Message = "Entity updated", Data = entityEntry.Entity };

        }
    }
}
