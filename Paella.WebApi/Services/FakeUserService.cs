using Microsoft.AspNetCore.Http;
using Paella.Infrastructure.Entities;

namespace Paella.WebApi.Services
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

        public PaellaUser GetUser(HttpContext context)
        {
            return User;
        }
    }
}