using NovaAPI.Entities.Models;

namespace NovaAPI.Tests.UnitTests
{
    public class ProductTests
    {
        [Fact]
        public void Price_DeveSerPositivo()
        {
            // Arrange
            var product = new Product { Price = 99.99m };

            // Act
            var isPositive = product.Price > 0;

            // Assert
            Assert.True(isPositive, "O preço do produto deve ser um valor positivo.");
        }

        [Fact]
        public void Name_DeveSerValido()
        {
            // Arrange
            var product = new Product { Name = "Produto Teste" };

            // Act
            var isValid = !string.IsNullOrEmpty(product.Name);

            // Assert
            Assert.True(isValid, "O nome do produto não deve ser nulo ou vazio.");
        }
    }
}
