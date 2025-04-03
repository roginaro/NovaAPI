using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Contexts;
using NovaAPI.Repositories.Interfaces;

namespace NovaAPI.Repositories.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(NovaAPIDbContext context) : base(context)
        {
        }

        public async Task<RepositoryOutput<Product>> GetByEntity(Product product)
        {
            var entityReturn = await _dbSet.FindAsync(product.ProductId);
            if (entityReturn == null)
            {
                return new RepositoryOutput<Product>() { Success = false, Message = "Product not found" };
            }
            return new RepositoryOutput<Product>() { Success = true, Message = "Add Success", Data = entityReturn };
        }

        public override async Task<RepositoryOutput<Product>> Update(Product product)
        {
            var entityFromDB = await this.GetByEntity(product);
            if (!entityFromDB.Success)
            {
                return new RepositoryOutput<Product>() { Success = false, Message = "Product not found", Data = product };
            }
            var entityEntry = _dbSet.Update(entityFromDB.Data);
            var returnSavechanges = await _context.SaveChangesAsync();
            if (returnSavechanges == 0)
            {
                return new RepositoryOutput<Product>() { Success = false, Message = "Update failed" };
            }
            return new RepositoryOutput<Product>() { Success = true, Message = "Product updated", Data = entityEntry.Entity };
        }
    }
}
