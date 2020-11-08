using BogusProvider.Entities;

namespace BogusProvider.FakeProductServices
{
    public interface IFakeProductsProvider
    {
        Product GenerateFakeProducts(int? maxProductBrandId, int? maxProductTypeId);
    }
}