using Microsoft.AspNetCore.Builder;
using Paella.Infrastructure.Seeds;

namespace Paella.WebApi.Extentions
{
    public static class DbSeedExtentions
    {
        public static void SeedUsers(this IApplicationBuilder app, PaellaUserSeeder seeder)
        {
            seeder.Seed();
        }

        public static void SeedProducts(this IApplicationBuilder app, PaellaProductSeeder seeder)
        {
            seeder.Seed();
        }
    }
}