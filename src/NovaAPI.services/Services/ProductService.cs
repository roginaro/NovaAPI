using NovaAPI.business.Models;
using NovaAPI.repositories.Interfaces;
using NovaAPI.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaAPI.services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _produto;

        public ProductService(IProductRepository produto)
        {
            _produto = produto;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _produto.GetAll();
        }

        public Task<Product> AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
