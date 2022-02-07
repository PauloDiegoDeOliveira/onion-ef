using AutoMapper;
using Empresa.Projeto.Application.Dtos.Especialidade;
using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Domain.Entitys;
using System;

namespace Empresa.Projeto.Application.Mappers
{
    public class MappingProfileUsuario : Profile
    {
        public MappingProfileUsuario()
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

            CreateMap<Especialidade, ReferenciaEspecialidadeDto>().ReverseMap();
            CreateMap<Especialidade, ViewEspecialidadeDto>().ReverseMap();
        }
    }
}