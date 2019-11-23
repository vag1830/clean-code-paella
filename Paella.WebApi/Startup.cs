using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Paella.Application.Services;
using Paella.Infrastructure.Seeds;
using Paella.Infrastructure.Services;
using Paella.WebApi.Extentions;
using WebApi.Services;

namespace Paella.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("All",
                builder =>
                {
                    builder.AllowAnyOrigin();
                });
            });

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddUseCases();
            services.AddPersistence(Configuration);
            services.AddIdentityAndAuthentication();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<TokenService, TokenService>();

            services.AddScoped<PaellaUserSeeder, PaellaUserSeeder>();
            services.AddScoped<PaellaProductSeeder, PaellaProductSeeder>();
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            PaellaUserSeeder userSeeder,
            PaellaProductSeeder productSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("All");

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCustomSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // endpoints.MapHealthChecks("/health");
            });

            app.SeedUsers(userSeeder);
            app.SeedProducts(productSeeder);
        }
    }
}