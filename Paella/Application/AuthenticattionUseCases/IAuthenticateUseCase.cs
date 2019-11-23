using Paella.Application.AuthenticattionUseCases.Parameters;
using Paella.Domain.Entities;

namespace Paella.Application.UseCases.Authenticate
{
    public interface IAuthenticateUseCase
    {
        PaellaUser Execute(AuthenticationInput input);
    }
}
