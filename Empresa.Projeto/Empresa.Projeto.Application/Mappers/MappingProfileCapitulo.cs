using AutoMapper;
using Empresa.Projeto.Application.Dtos.Progresso;
using Empresa.Projeto.Application.Dtos.Capitulo;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application.Mappers
{
    public class MappingProfileCapitulo : Profile
    {
        public MappingProfileCapitulo()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<PostCapituloDto, Capitulo>();
            CreateMap<PutCapituloDto, Capitulo>();
            CreateMap<Capitulo, ViewCapituloDto>();

            CreateMap<Progresso, ReferenciaProgressoDto>().ReverseMap();
            CreateMap<Progresso, ViewProgressoDto>().ReverseMap();
        }
    }
}
