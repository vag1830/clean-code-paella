using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Paella.WebApi.Extentions
{
    public static class SwaggerExtentions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Spanish Paella", Version = "v1" });
            });
        }

        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(options =>
            {

            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                options.RoutePrefix = "api/swagger";
            });
        }
    }
}