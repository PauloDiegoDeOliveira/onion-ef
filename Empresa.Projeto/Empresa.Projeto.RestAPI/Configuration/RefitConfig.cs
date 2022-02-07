using Empresa.Projeto.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace Empresa.Projeto.RestAPI.Configuration
{
    public static class RefitConfig
    {
        public static void AddRefitConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRefitClient<IApplicationCorreios>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("ExternalApiUrls:CorreiosUrl").Value);
            });
        }
    }
}