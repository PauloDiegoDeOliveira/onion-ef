using AutoMapper;
using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Domain.Entitys;
using System;

namespace Empresa.Projeto.Application.Mappers
{
    public class DtoToModelMappingPermissao : Profile
    {
        public DtoToModelMappingPermissao()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<PostPermissaoDto, Permissao>();
            CreateMap<PutPermissaoDto, Permissao>().ForMember(d => d.AlteradoEm, o => o.MapFrom(x => DateTime.Now)).ReverseMap();
            CreateMap<Permissao, ViewPermissaoDto>();
        }
    }
}