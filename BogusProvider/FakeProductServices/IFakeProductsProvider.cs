using BogusProvider.Entities;

namespace BogusProvider.FakeProductServices
{
    public interface IFakeProductsProvider
    {
        Product GenerateFakeProducts();
        string GenerateJsonProduct(Product product);
    }
}