using Microsoft.Extensions.DependencyInjection;
using Paella.Application.UseCases.Authenticate;
using Paella.Application.UseCases.Create;
using Paella.Application.UseCases.GetAll;
using Paella.Application.UseCases.GetById;
using Paella.Application.UseCases.Update;

namespace Paella.WebApi.Extentions
{
    public static class UseCaseExtentions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IGetAllUseCase, GetAllUseCase>();
            services.AddTransient<IGetByIdUseCase, GetByIdUseCase>();
            services.AddTransient<ICreateUseCase, CreateUseCase>();
            services.AddTransient<IUpdateUseCase, UpdateUseCase>();
            services.AddScoped<IAuthenticateUseCase, AuthenticateUseCase>();
        }
    }
}