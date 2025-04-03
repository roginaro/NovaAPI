using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Contexts;
using NovaAPI.Repositories.Repositories;
using NovaAPI.Services.Services;
using NovaAPI.Services.Validations;

namespace NovaAPI.Tests.IntegrationTests
{
    public class ProductServiceRepositoryIntegrationTests
    {
        private readonly DbContextOptions<NovaAPIDbContext> _options;

        public ProductServiceRepositoryIntegrationTests()
        {
            _options = new DbContextOptionsBuilder<NovaAPIDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task AddProduct_ShouldAddProductToDatabase()
        {
            // Arrange
            using (var context = new NovaAPIDbContext(_options))
            {
                var repository = new ProductRepository(context);
                var productValidation = new ProductValidation();

                var service = new ProductService(repository, productValidation);

                var productValid = new Product { Name = "Test Product", Description = "Test Description", Price = 10.0m, Image = "imag35.jpg" };
                var productNameNull = new Product { Name = "Test Product", Description = "Test Description", Price = 10.0m, Image = "imag34.jpr" };

                // Act
                var resultValid = await service.Add(productValid);
                var resultNameNull = await service.Add(productNameNull);
                await context.SaveChangesAsync();

                // Assert
                resultValid.Success.Should().BeTrue();
                resultNameNull.Success.Should().BeFalse();
                context.Set<Product>().Should().Contain(productValid);
                context.Set<Product>().Should().NotContain(productNameNull);
            }
        }
    }
}
