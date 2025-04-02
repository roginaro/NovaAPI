using Moq;
using NovaAPI.Services.Services;
using NovaAPI.Repositories.Interfaces;
using NovaAPI.Entities.Models;
using FluentValidation;
using NovaAPI.Entities.Base;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace NovaAPI.Tests.UnitTests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task Add_ValidProduct_ReturnsSuccessfulServiceOutput()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Product>>();
            var mockProductRepository = new Mock<IProductRepository>();
            var mockValidator = new Mock<IValidator<Product>>();

            var validProduct = new Product { Name = "Test Product", Description = "Test Description", Price = 10.0m, Image = "test.jpg" };

            mockValidator.Setup(v => v.Validate(validProduct))
                .Returns(new FluentValidation.Results.ValidationResult()); // Sem erros de validação

            mockRepository.Setup(r => r.Add(validProduct))
                .ReturnsAsync(new RepositoryOutput<Product> { Success = true, Data = validProduct });

            var service = new ProductService(mockRepository.Object, mockValidator.Object, mockProductRepository.Object);

            // Act
            var result = await service.Add(validProduct);

            // Assert
            result.Success.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(validProduct);
            result.Errors.Should().BeNull();

            mockRepository.Verify(r => r.Add(validProduct), Times.Once); // Verificando se o repositório foi chamado
        }

        [Fact]
        public async Task Add_InvalidProduct_ReturnsFailedServiceOutputWithErrors()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Product>>();
            var mockProductRepository = new Mock<IProductRepository>();
            var mockValidator = new Mock<IValidator<Product>>();

            var invalidProduct = new Product { Name = "", Description = "", Price = 0, Image = "invalid" };

            var validationErrors = new List<FluentValidation.Results.ValidationFailure>
        {
            new FluentValidation.Results.ValidationFailure("Name", "Name is required"),
            new FluentValidation.Results.ValidationFailure("Description", "Description is required")
        };

            mockValidator.Setup(v => v.Validate(invalidProduct))
                .Returns(new FluentValidation.Results.ValidationResult(validationErrors));

            var service = new ProductService(mockRepository.Object, mockValidator.Object, mockProductRepository.Object);

            // Act
            var result = await service.Add(invalidProduct);

            // Assert
            result.Success.Should().BeFalse();
            result.Data.Should().BeEquivalentTo(invalidProduct);
            result.Errors.Should().NotBeNullOrEmpty();
            result.Errors.Should().HaveCount(2);
            result.Errors.Should().Contain(e => e.Message == "Name is required");
            result.Errors.Should().Contain(e => e.Message == "Description is required");

            mockRepository.Verify(r => r.Add(invalidProduct), Times.Never); // Verificando que o repositório não foi chamado.
        }

        [Fact]
        public async Task Update_ValidProduct_ReturnsSuccessfulServiceOutput()
        {
            //Arrange
            var mockRepository = new Mock<IRepository<Product>>();
            var mockProductRepository = new Mock<IProductRepository>();
            var mockValidator = new Mock<IValidator<Product>>();

            var validProduct = new Product { Name = "Test Product", Description = "Test Description", Price = 10.0m, Image = "test.jpg" };

            mockValidator.Setup(v => v.Validate(validProduct))
                .Returns(new FluentValidation.Results.ValidationResult());

            mockProductRepository.Setup(r => r.Update(validProduct))
                .ReturnsAsync(new RepositoryOutput<Product> { Success = true, Data = validProduct });

            var service = new ProductService(mockRepository.Object, mockValidator.Object, mockProductRepository.Object);

            //Act
            var result = await service.Update(validProduct);

            //Assert
            result.Success.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(validProduct);
            result.Errors.Should().BeNull();

            mockProductRepository.Verify(r => r.Update(validProduct), Times.Once);

        }

        [Fact]
        public async Task Update_InvalidProduct_ReturnsFailedServiceOutputWithErrors()
        {
            //Arrange
            var mockRepository = new Mock<IRepository<Product>>();
            var mockProductRepository = new Mock<IProductRepository>();
            var mockValidator = new Mock<IValidator<Product>>();

            var invalidProduct = new Product { Name = "", Description = "", Price = 0, Image = "invalid" };

            var validationErrors = new List<FluentValidation.Results.ValidationFailure>
        {
            new FluentValidation.Results.ValidationFailure("Name", "Name is required"),
            new FluentValidation.Results.ValidationFailure("Description", "Description is required")
        };

            mockValidator.Setup(v => v.Validate(invalidProduct))
                .Returns(new FluentValidation.Results.ValidationResult(validationErrors));

            var service = new ProductService(mockRepository.Object, mockValidator.Object, mockProductRepository.Object);

            //Act
            var result = await service.Update(invalidProduct);

            //Assert
            result.Success.Should().BeFalse();
            result.Data.Should().BeEquivalentTo(invalidProduct);
            result.Errors.Should().NotBeNullOrEmpty();
            result.Errors.Should().HaveCount(2);
            result.Errors.Should().Contain(e => e.Message == "Name is required");
            result.Errors.Should().Contain(e => e.Message == "Description is required");

            mockProductRepository.Verify(r => r.Update(invalidProduct), Times.Never);

        }

    }

}