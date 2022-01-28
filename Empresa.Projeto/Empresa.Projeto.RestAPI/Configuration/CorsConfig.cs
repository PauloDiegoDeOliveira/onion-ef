using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.Projeto.RestAPI.Configuration
{
    public static class CorsConfig
    {
        public static void AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    var origins = configuration.GetValue<string>("CorsOrigins").Split(";");
                    builder
                        .WithOrigins(origins)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }
    }
}