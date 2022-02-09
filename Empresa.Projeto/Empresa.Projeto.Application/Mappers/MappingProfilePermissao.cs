using AutoMapper;
using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application.Mappers
{
    public class MappingProfilePermissao : Profile
    {
        public MappingProfilePermissao()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<PostPermissaoDto, Permissao>();
            CreateMap<PutPermissaoDto, Permissao>();
            CreateMap<Permissao, ViewPermissaoDto>();
            CreateMap<Permissao, ViewPermissaoUsuarioDto>().ReverseMap();
        }
    }
}