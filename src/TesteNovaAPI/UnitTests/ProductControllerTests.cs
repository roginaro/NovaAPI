using Microsoft.AspNetCore.Mvc;
using Moq;
using NovaAPI.api.Controllers;
using NovaAPI.Api.ViewModels;
using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;
using NovaAPI.Services.Interfaces.Materials;

namespace NovaAPI.Tests.UnitTests
{
    public class ProductControllerTests
    {
        public static IEnumerable<object[]> ServiceOutputTestData()
        {
            yield return new object[]
            {
            new ServiceOutput<Product>
            {
                Data = new Product()
            },
            typeof(OkObjectResult)
            };

            yield return new object[]
            {
            new ServiceOutput<Product>
            {
                Message = "Erro de teste",
                Errors = new List<ErrorBase> { new ErrorBase { Message = "teste" } }
            },
            typeof(BadRequestObjectResult)
            };
        }

        [Theory]
        [MemberData(nameof(ServiceOutputTestData))]
        public async Task AddProduct_ReturnsCorrectResult(ServiceOutput<Product> serviceOutput, Type expectedResultType)
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(service => service.Add(It.IsAny<Product>()))
                .ReturnsAsync(serviceOutput);

            var controller = new ProductController(mockProductService.Object);
            var productViewModel = new ProductViewModel
            {
                Name = "Test Product",
                Description = "Test Description",
                Price = 10.0m,
                Image = "test.jpg"
            };

            // Act
            var result = await controller.AddProduct(productViewModel);

            // Assert
            Assert.IsType(expectedResultType, result.Result);

            if (serviceOutput.Success)
            {
                var okResult = (OkObjectResult)result.Result;
                var actualServiceOutput = Assert.IsType<ServiceOutput<Product>>(okResult.Value);
                Assert.True(actualServiceOutput.Success);
            }
            else
            {
                var badRequestResult = (BadRequestObjectResult)result.Result;
                Assert.Equal(serviceOutput.Message, badRequestResult.Value);
            }
        }
    }
}