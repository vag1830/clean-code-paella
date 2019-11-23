using Paella.Application.AuthenticationUseCases.Parameters;
using Paella.Domain.Entities;

namespace Paella.Application.AuthenticationUseCases
{
    public interface IAuthenticateUseCase
    {
        PaellaUser Execute(AuthenticationInput input);
    }
}
