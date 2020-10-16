using BogusProvider.FakeProductServices;
using Microsoft.AspNetCore.Mvc;

namespace BogusProvider.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FakeProductController : ControllerBase
    {
        private readonly IFakeProductsProvider _fakeProduct;

        public FakeProductController(IFakeProductsProvider fakeProduct)
        {
            _fakeProduct = fakeProduct;
        }

        [HttpGet]
        public ActionResult<string> GetFakeProduct()
        {
            var product = _fakeProduct.GenerateFakeProducts();
            return Ok(_fakeProduct.GenerateJsonProduct(product));
        }
    }
}