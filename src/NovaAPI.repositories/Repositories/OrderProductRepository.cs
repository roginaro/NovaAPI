using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Contexts;

namespace NovaAPI.Repositories.Repositories
{
    public class OrderProductRepository : BaseRepository<OrderProduct>
    {
        public OrderProductRepository(NovaAPIDbContext context) : base(context)
        {
        }

    }
}
