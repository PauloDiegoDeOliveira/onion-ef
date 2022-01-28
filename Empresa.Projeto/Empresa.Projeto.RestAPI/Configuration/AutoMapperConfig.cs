using Empresa.Projeto.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.Projeto.RestAPI.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(DtoToModelMappingUsuario),
                typeof(DtoToModelMappingPermissao)
                );
        }
    }
}