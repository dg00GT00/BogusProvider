using Bogus;
using BogusProvider.Entities;

namespace BogusProvider.FakeProductServices
{
    public class FakeProductsProvider : IFakeProductsProvider
    {
        public Product GenerateFakeProducts()
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