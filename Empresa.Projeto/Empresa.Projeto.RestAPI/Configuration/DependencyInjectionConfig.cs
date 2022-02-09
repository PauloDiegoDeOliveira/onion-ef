using Empresa.Projeto.Application;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Services;
using Empresa.Projeto.Infrastructure.Data.Repositorys;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Empresa.Projeto.RestAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
            services.AddScoped<IApplicationUsuario, ApplicationUsuario>();
            services.AddScoped<IServiceUsuario, ServiceUsuario>();

            services.AddScoped<IRepositoryPermissao, RepositoryPermissao>();
            services.AddScoped<IApplicationPermissao, ApplicationPermissao>();
            services.AddScoped<IServicePermissao, ServicePermissao>();

            services.AddScoped<IRepositoryUploadForm, RepositoryUploadForm>();
            services.AddScoped<IApplicationUploadForm, ApplicationUploadForm>();
            services.AddScoped<IServiceUploadForm, ServiceUploadForm>();

            services.AddScoped<IRepositoryUploadB64, RepositoryUploadB64>();
            services.AddScoped<IApplicationUploadB64, ApplicationUploadB64>();
            services.AddScoped<IServiceUploadB64, ServiceUploadB64>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}