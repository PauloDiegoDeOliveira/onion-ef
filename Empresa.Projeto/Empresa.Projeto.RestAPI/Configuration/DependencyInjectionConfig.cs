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

            services.AddScoped<IRepositoryEspecialidade, RepositoryEspecialidade>();
            services.AddScoped<IApplicationEspecialidade, ApplicationEspecialidade>();
            services.AddScoped<IServiceEspecialidade, ServiceEspecialidade>();

            services.AddScoped<IRepositoryProgresso, RepositoryProgresso>();
            services.AddScoped<IApplicationProgresso, ApplicationProgresso>();
            services.AddScoped<IServiceProgresso, ServiceProgresso>();

            services.AddScoped<IRepositoryCapitulo, RepositoryCapitulo>();
            services.AddScoped<IApplicationCapitulo, ApplicationCapitulo>();
            services.AddScoped<IServiceCapitulo, ServiceCapitulo>();

            services.AddScoped<IRepositoryUnidade, RepositoryUnidade>();
            services.AddScoped<IApplicationUnidade, ApplicationUnidade>();
            services.AddScoped<IServiceUnidade, ServiceUnidade>();

            services.AddScoped<IRepositoryClienteForm, RepositoryClienteForm>();
            services.AddScoped<IApplicationClienteForm, ApplicationClienteForm>();
            services.AddScoped<IServiceClienteForm, ServiceClienteForm>();

            services.AddScoped<IRepositoryAlunoB64, RepositoryAlunoB64>();
            services.AddScoped<IApplicationAlunoB64, ApplicationAlunoB64>();
            services.AddScoped<IServiceAlunoB64, ServiceAlunoB64>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}