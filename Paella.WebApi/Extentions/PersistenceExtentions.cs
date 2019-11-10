using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paella.Application.Persistence;
using Paella.Infrastructure;

namespace Paella.WebApi.Extentions
{
    public static class PersistenceExtentions
    {
        public static void AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SQLServer");
            services.AddDbContext<PaellaDbContext>(builder =>
            {
                builder.UseSqlServer(connectionString);
            });
            //services.AddSingleton<IProductRepository, InMemoryProductRepository>();
            services.AddTransient<IProductRepository, ProductEFCoreRepository>();
        }
    }
}