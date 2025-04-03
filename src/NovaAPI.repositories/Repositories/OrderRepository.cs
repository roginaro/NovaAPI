using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Contexts;

namespace NovaAPI.Repositories.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(NovaAPIDbContext context) : base(context)
        {
        }

        public async Task<RepositoryOutput<Order>> GetByEntity(Order order)
        {
            var entityReturn = await _dbSet.FindAsync(order.OrderId);
            if (entityReturn == null)
            {
                return new RepositoryOutput<Order>() { Success = false, Message = "Entity not found" };
            }
            return new RepositoryOutput<Order>() { Success = true, Message = "Add Success", Data = entityReturn };

        }
        public override async Task<RepositoryOutput<Order>> Update(Order order)
        {
            var entityFromDB = await this.GetByEntity(order);
            if (!entityFromDB.Success)
            {
                return new RepositoryOutput<Order>() { Success = false, Message = "Entity not found", Data = order };
            }
            var entityEntry = _dbSet.Update(entityFromDB.Data);
            var returnSavechanges = await _context.SaveChangesAsync();
            if (returnSavechanges == 0)
            {
                return new RepositoryOutput<Order>() { Success = false, Message = "Update failed" };
            }
            return new RepositoryOutput<Order>() { Success = true, Message = "Entity updated", Data = entityEntry.Entity };
        }
    }

}
