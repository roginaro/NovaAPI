using Microsoft.EntityFrameworkCore;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Contexts;
using NovaAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaAPI.Repositories.Repositories
{
    public class ProdutoRepository : IProductRepository
    {
        protected readonly DbSet<Product> _dbSet;

        public ProdutoRepository(NovaAPIDbContext context)
        {
            _dbSet = context.Set<Product>();
        }

        public Task<Product> Add(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _dbSet.ToListAsync();
            return products;
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
