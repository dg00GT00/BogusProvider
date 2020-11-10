using Bogus;
using BogusProvider.Entities.Identity;
using BogusProvider.FakeServices.Interfaces;

namespace BogusProvider.FakeServices
{
    /// <summary>
    /// Fake user provider
    /// </summary>
    public class FakeUserProvider : IFakeUserProvider
    {
        /// <summary>
        /// Generate a fake user
        /// </summary>
        /// <returns>the populate fake user</returns>
        public AppUser GetFakeUser()
        {
            var address = new Faker<Address>()
                .Rules((faker, add) =>
                {
                    add.City = faker.Address.City();
                    add.State = faker.Address.State();
                    add.Street = faker.Address.StreetName();
                    add.FirstName = faker.Name.FirstName();
                    add.LastName = faker.Name.LastName();
                    add.ZipCode = faker.Address.ZipCode();
                });
            var appUser = new Faker<AppUser>()
                .Rules((faker, user) =>
                {
                    user.Email = faker.Person.Email;
                    user.Address = address;
                });
            return appUser.Generate();
        }
    }
}