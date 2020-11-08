using BogusProvider.Entities;
using BogusProvider.FakeProductServices;
using BogusProvider.ModelValidation;
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
        public ActionResult<Product> GetFakeProduct([FromQuery] RandomId randomId)
        {
            var product = _fakeProduct.GenerateFakeProducts(randomId.BrandId, randomId.TypeId);
            return Ok(product);
        }
    }
}