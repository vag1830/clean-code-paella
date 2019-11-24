using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Paella.Infrastructure;

namespace Paella.Migrations
{
    public class ContextFactory : IDesignTimeDbContextFactory<PaellaDbContext>
    {
        public PaellaDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true, true)
              .Build();

            var connectionString = config.GetConnectionString("SQLServer");

            var optionsBuilder = new DbContextOptionsBuilder<PaellaDbContext>();

            optionsBuilder.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("Paella.Migrations"));

            return new PaellaDbContext(optionsBuilder.Options);
        }
    }
}