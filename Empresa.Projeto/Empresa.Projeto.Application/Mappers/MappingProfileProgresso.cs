using AutoMapper;
using Empresa.Projeto.Application.Dtos.Progresso;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application.Mappers
{
    public class MappingProfileProgresso : Profile
    {
        public MappingProfileProgresso()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<PostProgressoDto, Progresso>();
            CreateMap<PutProgressoDto, Progresso>();
            CreateMap<Progresso, ViewProgressoDto>();
        }
    }
}
