using BogusProvider.Entities;
using BogusProvider.Entities.Identity;
using BogusProvider.FakeServices.Interfaces;
using BogusProvider.ModelValidation;
using Microsoft.AspNetCore.Mvc;

namespace BogusProvider.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FakeController : ControllerBase
    {
        private readonly IFakeProductsProvider _fakeProduct;
        private readonly IFakeUserProvider _fakeUser;

        public FakeController(IFakeProductsProvider fakeProduct, IFakeUserProvider fakeUser)
        {
            _fakeProduct = fakeProduct;
            _fakeUser = fakeUser;
        }

        [HttpGet("product")]
        public ActionResult<Product> GetFakeProduct([FromQuery] RandomId randomId)
        {
            var product = _fakeProduct.GenerateFakeProduct(randomId.BrandId, randomId.TypeId);
            return Ok(product);
        }

        [HttpGet("user")]
        public ActionResult<AppUser> GetFakeUser()
        {
            var user = _fakeUser.GetFakeUser();
            return Ok(user);
        }
    }
}