using Paella.Application.Services;
using Paella.Domain.Entities;

namespace Paella.Infrastructure.Services
{
    public class FakeUserService : IUserService
    {
        public PaellaUser User = new PaellaUser();

        public PaellaUser FindByName(string name)
        {
            return User;
        }

        public bool CheckPassword(PaellaUser user, string password)
        {
            return true;
        }

        public PaellaUser Create(PaellaUser user, string password)
        {
            User = user;

            return User;
        }
    }
}