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

        public override Task<RepositoryOutput<Order>> Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }

}
