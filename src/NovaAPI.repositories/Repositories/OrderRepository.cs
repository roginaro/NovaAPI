using Microsoft.EntityFrameworkCore;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Contexts;
using NovaAPI.Repositories.Interfaces;

namespace NovaAPI.Repositories.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(NovaAPIDbContext context) : base(context)
        {
        }
    }
    
}
