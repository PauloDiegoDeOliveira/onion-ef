using AutoMapper;
using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application.Mappers
{
    public class DtoToModelMappingUsuario : Profile
    {
        public DtoToModelMappingUsuario()
        {
            Map();
        }

        private void Map()
        {           
            CreateMap<Usuario, ViewUsuarioDto>();           
        }
    }
}