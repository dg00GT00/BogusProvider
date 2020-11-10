using BogusProvider.Entities;

namespace BogusProvider.FakeServices.Interfaces
{
    public interface IFakeProductsProvider
    {
        Product GenerateFakeProduct(int? maxProductBrandId, int? maxProductTypeId);
    }
}