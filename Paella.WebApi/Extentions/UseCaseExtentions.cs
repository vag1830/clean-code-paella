using Microsoft.Extensions.DependencyInjection;
using Paella.Application.ProductUseCases.Create;
using Paella.Application.ProductUseCases.GetAll;
using Paella.Application.ProductUseCases.GetById;
using Paella.Application.ProductUseCases.Update;
using Paella.Application.UseCases.Update;
using Paella.WebApi.AuthenticationUseCases;
using CreateOrderUseCase = Paella.Application.OrderUseCases.Create.CreateUseCase;
using ICreateOrderUseCase = Paella.Application.OrderUseCases.Create.ICreateUseCase;

namespace Paella.WebApi.Extentions
{
    public static class UseCaseExtentions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IGetAllUseCase, GetAllUseCase>();
            services.AddScoped<IGetByIdUseCase, GetByIdUseCase>();
            services.AddScoped<ICreateUseCase, CreateUseCase>();
            services.AddScoped<IUpdateUseCase, UpdateUseCase>();

            services.AddScoped<ICreateOrderUseCase, CreateOrderUseCase>();

            services.AddScoped<IAuthenticateUseCase, AuthenticateUseCase>();
        }
    }
}