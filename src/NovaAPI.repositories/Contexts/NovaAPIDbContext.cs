using NovaAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using NovaAPI.Repositories.Configurations;

namespace NovaAPI.Repositories.Contexts;

public class NovaAPIDbContext : DbContext
{
    public NovaAPIDbContext(DbContextOptions<NovaAPIDbContext> options)
        : base(options)
    {
    }

    //public DbSet<Customer> Customers { get; set; }
    //public DbSet<Order> Order { get; set; }
    public DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        //modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        foreach(var property in modelBuilder.Model.GetEntityTypes()
                                                   .SelectMany(e => e.GetProperties()
                                                   .Where(p => p.ClrType == typeof(string))))
        {
            if (property.GetMaxLength() == null)
            {
                property.SetMaxLength(100);
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}