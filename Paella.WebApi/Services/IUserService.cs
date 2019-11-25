using Microsoft.AspNetCore.Http;
using Paella.Infrastructure.Entities;

namespace Paella.WebApi.Services
{
    public interface IUserService
    {
        PaellaUser FindByName(string name);

        PaellaUser GetUser(HttpContext context);

        bool CheckPassword(PaellaUser user, string password);

        PaellaUser Create(PaellaUser user, string password);
    }
}