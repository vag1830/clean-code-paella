using Paella.Application.AuthenticationUseCases.Parameters;
using Paella.Infrastructure.Entities;

namespace Paella.Application.AuthenticationUseCases
{
    public interface IAuthenticateUseCase
    {
        PaellaUser Execute(AuthenticationInput input);
    }
}
