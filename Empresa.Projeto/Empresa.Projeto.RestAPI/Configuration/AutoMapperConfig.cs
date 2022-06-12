using Empresa.Projeto.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.Projeto.RestAPI.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(MappingProfileUsuario),
                typeof(MappingProfilePermissao),
                typeof(MappingProfileUploadForm),
                typeof(MappingProfileEspecialidade),
                typeof(MappingProfileUploadB64),
                typeof(MappingProfileProgresso),
                typeof(MappingProfileCapitulo),
                typeof(MappingProfileUnidade),
                typeof(MappingProfileClienteForm),
                typeof(MappingProfileAlunoB64)
                );
        }
    }
}