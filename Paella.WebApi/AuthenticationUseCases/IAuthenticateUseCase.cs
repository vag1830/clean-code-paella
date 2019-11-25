using Paella.Infrastructure.Entities;
using Paella.WebApi.AuthenticationUseCases.Parameters;

namespace Paella.WebApi.AuthenticationUseCases
{
    public interface IAuthenticateUseCase
    {
        PaellaUser Execute(AuthenticationInput input);
    }
}
