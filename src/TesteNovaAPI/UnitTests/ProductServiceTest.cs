using FluentAssertions;
using FluentValidation;
using Moq;
using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Interfaces;
using NovaAPI.Services.Services;

namespace NovaAPI.Tests.UnitTests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task Add_ValidProduct_ReturnsSuccessfulServiceOutput()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Product>>();
            var mockIRepository = new Mock<IRepository<Product>>();
            var mockValidator = new Mock<IValidator<Product>>();

            var validProduct = new Product { Name = "Test Product", Description = "Test Description", Price = 10.0m, Image = "test.jpg" };

            mockValidator.Setup(v => v.Validate(validProduct))
                .Returns(new FluentValidation.Results.ValidationResult()); // Sem erros de validação

            mockIRepository.Setup(r => r.Add(validProduct))
                .ReturnsAsync(new RepositoryOutput<Product> { Success = true, Data = validProduct });

            var service = new ProductService(mockIRepository.Object, mockValidator.Object);

            // Act
            var result = await service.Add(validProduct);

            // Assert
            result.Success.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(validProduct);
            result.Errors.Should().BeNull();

            mockIRepository.Verify(r => r.Add(validProduct), Times.Once);
        }

        [Fact]
        public async Task Add_InvalidProduct_ReturnsFailedServiceOutputWithErrors()
        {
            // Arrange
            var mockIRepositoryProduct = new Mock<IRepository<Product>>();
            var mockValidator = new Mock<IValidator<Product>>();

            var invalidProduct = new Product { Name = "", Description = "", Price = 0, Image = "invalid" };

            var validationErrors = new List<FluentValidation.Results.ValidationFailure>
        {
            new FluentValidation.Results.ValidationFailure("Name", "Name is required"),
            new FluentValidation.Results.ValidationFailure("Description", "Description is required")
        };

            mockValidator.Setup(v => v.Validate(invalidProduct))
                .Returns(new FluentValidation.Results.ValidationResult(validationErrors));

            var service = new ProductService(mockIRepositoryProduct.Object, mockValidator.Object);

            // Act
            var result = await service.Add(invalidProduct);

            // Assert
            result.Success.Should().BeFalse();
            result.Data.Should().BeEquivalentTo(invalidProduct);
            result.Errors.Should().NotBeNullOrEmpty();
            result.Errors.Should().HaveCount(2);
            result.Errors.Should().Contain(e => e.Message == "Name is required");
            result.Errors.Should().Contain(e => e.Message == "Description is required");

            mockIRepositoryProduct.Verify(r => r.Add(invalidProduct), Times.Never); // Verificando que o repositório não foi chamado.
        }

        [Fact]
        public async Task Update_ValidProduct_ReturnsSuccessfulServiceOutput()
        {
            //Arrange
            var mockIRepositoryProduct = new Mock<IRepository<Product>>();
            var mockValidator = new Mock<IValidator<Product>>();

            var validProduct = new Product { Name = "Test Product", Description = "Test Description", Price = 10.0m, Image = "test.jpg" };

            mockValidator.Setup(v => v.Validate(validProduct))
                .Returns(new FluentValidation.Results.ValidationResult());

            mockIRepositoryProduct.Setup(r => r.Update(validProduct))
                .ReturnsAsync(new RepositoryOutput<Product> { Success = true, Data = validProduct });

            var service = new ProductService(mockIRepositoryProduct.Object, mockValidator.Object);

            //Act
            var result = await service.Update(validProduct);

            //Assert
            result.Success.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(validProduct);
            result.Errors.Should().BeNull();

            mockIRepositoryProduct.Verify(r => r.Update(validProduct), Times.Once);

        }

        [Fact]
        public async Task Update_InvalidProduct_ReturnsFailedServiceOutputWithErrors()
        {
            //Arrange
            var mockIRepositoryProduct = new Mock<IRepository<Product>>();
            var mockValidator = new Mock<IValidator<Product>>();
            var invalidProduct = new Product { Name = "", Description = "", Price = 0, Image = "invalid" };
            var validationErrors = new List<FluentValidation.Results.ValidationFailure>
        {
            new FluentValidation.Results.ValidationFailure("Name", "Name is required"),
            new FluentValidation.Results.ValidationFailure("Description", "Description is required")
        };

            mockValidator.Setup(v => v.Validate(invalidProduct))
                .Returns(new FluentValidation.Results.ValidationResult(validationErrors));
            var service = new ProductService(mockIRepositoryProduct.Object, mockValidator.Object);

            //Act
            var result = await service.Update(invalidProduct);

            //Assert
            result.Success.Should().BeFalse();
            result.Data.Should().BeEquivalentTo(invalidProduct);
            result.Errors.Should().NotBeNullOrEmpty();
            result.Errors.Should().HaveCount(2);
            result.Errors.Should().Contain(e => e.Message == "Name is required");
            result.Errors.Should().Contain(e => e.Message == "Description is required");

            mockIRepositoryProduct.Verify(r => r.Update(invalidProduct), Times.Never);

        }

    }

}