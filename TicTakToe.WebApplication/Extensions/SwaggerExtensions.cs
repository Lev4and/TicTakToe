using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TicTakToe.WebApplication.Extensions
{
    internal static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
                options.AddServer();
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }

        private static void AddServer(this SwaggerGenOptions options)
        {
            var serverUrl = Environment.GetEnvironmentVariable("BACKEND_URL");

            if (!string.IsNullOrEmpty(serverUrl))
            {
                options.AddServer(new OpenApiServer() { Url = serverUrl });
            }
        }
    }
}
