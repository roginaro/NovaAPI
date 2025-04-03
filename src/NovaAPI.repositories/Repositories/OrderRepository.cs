using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Contexts;

namespace NovaAPI.Repositories.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(NovaAPIDbContext context) : base(context)
        {
        }
    }

}
