using Empresa.Projeto.Application.Validations.AlunoB64;
using Empresa.Projeto.Application.Validations.Capitulo;
using Empresa.Projeto.Application.Validations.ClienteForm;
using Empresa.Projeto.Application.Validations.Especialidade;
using Empresa.Projeto.Application.Validations.Permissao;
using Empresa.Projeto.Application.Validations.Progresso;
using Empresa.Projeto.Application.Validations.Unidade;
using Empresa.Projeto.Application.Validations.UploadB64;
using Empresa.Projeto.Application.Validations.UploadForm;
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
                    p.RegisterValidatorsFromAssemblyContaining<PutUsuarioValidator>();

                    p.RegisterValidatorsFromAssemblyContaining<PostPermissaoValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<PutPermissaoValidator>();

                    p.RegisterValidatorsFromAssemblyContaining<PostUploadFormValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<PutUploadFormValidator>();

                    p.RegisterValidatorsFromAssemblyContaining<PostUploadB64Validator>();
                    p.RegisterValidatorsFromAssemblyContaining<PutUploadB64Validator>();

                    p.RegisterValidatorsFromAssemblyContaining<PostEspecialidadeValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<PutEspecialidadeValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<ReferenciaEspecialidadeValidator>();

                    p.RegisterValidatorsFromAssemblyContaining<PostProgressoValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<PutProgressoValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<ReferenciaProgressoValidator>();

                    p.RegisterValidatorsFromAssemblyContaining<PostCapituloValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<PutCapituloValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<ReferenciaCapituloValidator>();

                    p.RegisterValidatorsFromAssemblyContaining<PostUnidadeValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<PutUnidadeValidator>();

                    p.RegisterValidatorsFromAssemblyContaining<PostClienteFormValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<PutClienteFormValidator>();

                    p.RegisterValidatorsFromAssemblyContaining<PostAlunoB64Valitator>();
                    p.RegisterValidatorsFromAssemblyContaining<PutAlunoB64Validator>();

                    p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                });
        }
    }
}