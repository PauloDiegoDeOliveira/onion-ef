using AutoMapper;
using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Domain.Entitys;
using System;

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
            CreateMap<PostUsuarioDto, Usuario>();
            CreateMap<PutUsuarioDto, Usuario>().ForMember(d => d.AlteradoEm, o => o.MapFrom(x => DateTime.Now));
            CreateMap<Usuario, ViewUsuarioDto>();
            CreateMap<Usuario, ViewAposAutenticacaoDto>().ReverseMap();
            CreateMap<Usuario, ViewUsuarioPermissaoDto>().ReverseMap(); 
        }
    }
}