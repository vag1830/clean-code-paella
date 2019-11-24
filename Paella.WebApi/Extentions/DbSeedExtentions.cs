using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Paella.Infrastructure.Seeds;

namespace Paella.WebApi.Extentions
{
    public static class DbSeedExtentions
    {
        public static void AddDatabaseSeeders(this IServiceCollection services)
        {
            services.AddScoped<ISeeder, PaellaUserSeeder>();
            services.AddScoped<ISeeder, PaellaProductSeeder>();
        }

        public static void SeedDatabase(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var seeders = serviceProvider.GetServices<ISeeder>();

            foreach (var seeder in seeders)
            {
                seeder.Seed();
            }
        }
    }
}