using AutoMapper;
using Empresa.Projeto.Application.Dtos.Capitulo;
using Empresa.Projeto.Application.Dtos.Unidade;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application.Mappers
{
    public class MappingProfileUnidade : Profile
    {
        public MappingProfileUnidade()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<PostUnidadeDto, Unidade>();
            CreateMap<PutUnidadeDto, Unidade>();
            CreateMap<Unidade, ViewUnidadeDto>();

            CreateMap<Capitulo, ReferenciaCapituloDto>().ReverseMap();
            CreateMap<Capitulo, ViewCapituloDto>().ReverseMap();
        }
    }
}
