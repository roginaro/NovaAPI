using NovaAPI.business.Models;
using NovaAPI.repositories.Interfaces;
using NovaAPI.repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaAPI.repositories.Repositories
{
    public class ProdutoRepository : IProductRepository
    {
        private readonly List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 999.99m, Image = "laptop.jpg" },
                new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 699.99m, Image = "smartphone.jpg" },
                new Product { Id = 3, Name = "Headphones", Description = "Noise-cancelling headphones", Price = 199.99m, Image = "headphones.jpg" },
                new Product { Id = 4, Name = "Smartwatch", Description = "Feature-rich smartwatch", Price = 299.99m, Image = "smartwatch.jpg" },
                new Product { Id = 5, Name = "Tablet", Description = "High-resolution tablet", Price = 399.99m, Image = "tablet.jpg" },
                new Product { Id = 6, Name = "Camera", Description = "Digital camera with 4K video", Price = 499.99m, Image = "camera.jpg" }
            };

        public Task<Product> Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            return Task.FromResult<IEnumerable<Product>>(products);
        }

        public Task<Product> GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                throw new KeyNotFoundException($"Product with Id {id} not found.");
            return Task.FromResult(product);
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
