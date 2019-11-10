using Paella.Domain.Entities;

namespace Paella.Application.Services
{
    public interface IUserService
    {
        PaellaUser FindByName(string name);

        bool CheckPassword(PaellaUser user, string password);

        PaellaUser Create(PaellaUser user, string password);
    }
}