using BogusProvider.Controllers;
using BogusProvider.Entities;
using BogusProvider.FakeProductServices;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Uri = System.Uri;

namespace Tests
{
    public class FakeProductControllerTests
    {
        private FakeProductController _sut;

        public FakeProductControllerTests()
        {
            _sut = new FakeProductController(new FakeProductsProvider());
        }

        [Fact]
        public void GetFakeProducts_ShouldReturnASetOfFakeProducts()
        {
            // Arrange
            // Act
            var actionResult = _sut.GetFakeProduct();
            // Assert
            var actionProduct = Assert.IsType<ActionResult<Product>>(actionResult);
            var product = Assert.IsType<Product>(((OkObjectResult) actionProduct.Result).Value);
            Assert.False(string.IsNullOrEmpty(product.Name));
            Assert.False(string.IsNullOrEmpty(product.Description));
            Assert.False(string.IsNullOrEmpty(product.ProductBrand.Name));
            Assert.False(string.IsNullOrEmpty(product.ProductType.Name));
            Assert.IsType<decimal>(product.Price);
            Assert.Contains("http", new Uri(product.PictureUrl).Scheme);
        }
    }
}