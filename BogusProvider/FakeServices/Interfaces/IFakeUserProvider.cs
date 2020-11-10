using BogusProvider.Entities.Identity;

namespace BogusProvider.FakeServices.Interfaces
{
    public interface IFakeUserProvider
    {
        AppUser GetFakeUser();
    }
}