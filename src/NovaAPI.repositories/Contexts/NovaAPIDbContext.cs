using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;

namespace NovaAPI.Repositories.Contexts;

public class NovaAPIDbContext : DbContext
{
    public DbSet<Customer> Users { get; set; }
    public DbSet<Order> Categories { get; set; }
    public DbSet<Product> Transactions { get; set; }

    public NovaAPIDbContext(DbContextOptions<NovaAPIDbContext> options)
        : base(options)
    {
    }
}