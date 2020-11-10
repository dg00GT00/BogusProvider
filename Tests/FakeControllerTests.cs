using System;
using BogusProvider.Controllers;
using BogusProvider.Entities;
using BogusProvider.Entities.Identity;
using BogusProvider.FakeServices;
using BogusProvider.ModelValidation;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Tests
{
    public class FakeControllerTests
    {
        private FakeController _sut;

        public FakeControllerTests()
        {
            _sut = new FakeController(new FakeProductsProvider(), new FakeUserProvider());
        }

        [Fact]
        public void GetFakeProducts_ShouldReturnASetOfFakeProducts()
        {
            // Arrange
            var randomId = new RandomId {BrandId = 10, TypeId = 20};
            // Act
            var actionResult = _sut.GetFakeProduct(randomId);
            // Assert
            var actionProduct = Assert.IsType<ActionResult<Product>>(actionResult);
            var product = Assert.IsType<Product>(((OkObjectResult) actionProduct.Result).Value);
            Assert.False(string.IsNullOrEmpty(product.Name));
            Assert.False(string.IsNullOrEmpty(product.Description));
            Assert.False(string.IsNullOrEmpty(product.ProductBrand.Name));
            Assert.False(string.IsNullOrEmpty(product.ProductType.Name));
            Assert.True(10 >= product.ProductBrand.Id);
            Assert.True(20 >= product.ProductType.Id);
            Assert.IsType<decimal>(product.Price);
            Assert.Contains("http", new Uri(product.PictureUrl).Scheme);
        }
        
        [Fact]
        public void GetFakeUser_ShouldReturnAFakeUser()
        {
            // Arrange
            // Act
            var actionResult = _sut.GetFakeUser();
            // Assert
            var actionUser = Assert.IsType<ActionResult<AppUser>>(actionResult);
            var user = Assert.IsType<AppUser>(((OkObjectResult) actionUser.Result).Value);
            var address = user.Address;
            Assert.False(string.IsNullOrEmpty(address.City));
            Assert.False(string.IsNullOrEmpty(address.State));
            Assert.False(string.IsNullOrEmpty(address.Street));
            Assert.False(string.IsNullOrEmpty(address.FirstName));
            Assert.False(string.IsNullOrEmpty(address.LastName));
            Assert.False(string.IsNullOrEmpty(address.ZipCode));
            Assert.False(string.IsNullOrEmpty(user.Email));

        }
    }
}