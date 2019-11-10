using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Paella.Application.Persistence;
using Paella.Application.UseCases.Create;
using Paella.Application.UseCases.GetAll;
using Paella.Application.UseCases.GetById;
using Paella.Application.UseCases.Update;
using Paella.Infrastructure;

namespace Paella.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMemoryCache();

            // TODO: move to an extension
            services.AddTransient<IGetAllUseCase, GetAllUseCase>();
            services.AddTransient<IGetByIdUseCase, GetByIdUseCase>();
            services.AddTransient<ICreateUseCase, CreateUseCase>();
            services.AddTransient<IUpdateUseCase, UpdateUseCase>();

            // TODO: move to an extension
            var connectionString = Configuration.GetConnectionString("SQLServer");
            services.AddDbContext<ProductDbContext>(builder =>
            {
                builder.UseSqlServer(connectionString);
                // builder.EnableSensitiveDataLogging();
                // builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            //services.AddSingleton<IProductRepository, InMemoryProductRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
