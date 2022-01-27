using Empresa.Projeto.Application.Validations.Permissao;
using Empresa.Projeto.Application.Validations.Usuario;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Empresa.Projeto.RestAPI.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddJsonOptions(p =>
                {
                    p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddFluentValidation(p =>
                {
                    //p.RegisterValidatorsFromAssemblyContaining<Startup>();
                    p.RegisterValidatorsFromAssemblyContaining<PostUsuarioValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<PostPermissaoValidator>();
                    p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                });
        }
    }
}