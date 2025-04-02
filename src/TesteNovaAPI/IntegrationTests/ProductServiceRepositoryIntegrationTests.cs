using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Moq;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Contexts;
using NovaAPI.Repositories.Repositories;
using NovaAPI.Services.Services;
using NovaAPI.Services.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                //var validatorMock = new Mock<FluentValidation.IValidator<Product>>();
                //validatorMock.Setup(v => v.Validate(It.IsAny<Product>()))
                //    .Returns(new FluentValidation.Results.ValidationResult()); // Sem erros de validação

                var productValidation = new ProductValidation();

                var service = new ProductService(repository, productValidation); // Passando o ProductRepository duas vezes

                var product = new Product { Name = "Test Product", Description = "Test Description", Price = 10.0m, Image = "imag35.jpg" };
                var product2 = new Product { Name = "Test Product", Description = "Test Description", Price = 10.0m ,Image = "imag34.jpr" };

                // Act
                var result = await service.Add(product);
                var result2 = await service.Add(product2);
                await context.SaveChangesAsync();

                // Assert
                result.Success.Should().BeTrue();
                result2.Success.Should().BeTrue();
                context.Set<Product>().Should().Contain(product);
                context.Set<Product>().Should().Contain(product2);
            }
        }
    }
}
