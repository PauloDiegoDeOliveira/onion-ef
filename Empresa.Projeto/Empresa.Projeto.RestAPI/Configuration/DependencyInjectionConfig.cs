using Empresa.Projeto.Application;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Infrastructure.Data.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.Projeto.RestAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
            services.AddScoped<IApplicationServiceUsuario, ApplicationServiceUsuario>();           
        }
    }
}
