using Bogus;
using BogusProvider.Entities;

namespace BogusProvider.FakeProductServices
{
    /// <summary>
    /// Provides a fake product set
    /// </summary>
    public class FakeProductsProvider : IFakeProductsProvider
    {
        /// <summary>
        /// Generate a fake product set based on some entities types
        /// </summary>
        /// <param name="maxProductBrandId">the max limit number used to generate a random number
        ///     which will be used to feed the Id property of the ProductBrand navigational property</param>
        /// <param name="maxProductTypeId">the max limit number used to generate a random number
        ///     which will be used to feed the Id property of the ProductType navigational property</param>
        /// <returns></returns>
        public Product GenerateFakeProducts(int? maxProductBrandId, int? maxProductTypeId)
        {
            var productType = new Faker<ProductType>()
                .RuleFor(product1 => product1.Name, faker => faker.Commerce.Categories(1)[0]);
            var productBrand = new Faker<ProductBrand>()
                .RuleFor(brand => brand.Name, faker => faker.Company.CompanyName());

            var product = new Faker<Product>()
                .Rules((faker, product1) =>
                {
                    product1.Name = faker.Commerce.ProductName();
                    product1.Description = faker.Commerce.ProductDescription();
                    product1.Price = decimal.Parse(faker.Commerce.Price(max:100M));
                    product1.PictureUrl = faker.Image.PicsumUrl();
                    product1.ProductType = productType;
                    product1.ProductBrand = productBrand;
                });

            return product.Generate();
        }
    }
}