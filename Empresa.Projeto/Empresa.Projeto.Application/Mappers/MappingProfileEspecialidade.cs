using AutoMapper;
using Empresa.Projeto.Application.Dtos.Especialidade;
using Empresa.Projeto.Application.Dtos.Ordem;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application.Mappers
{
    public class MappingProfileEspecialidade : Profile
    {
        public MappingProfileEspecialidade()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<PostEspecialidadeDto, Especialidade>();
            CreateMap<Especialidade, ViewEspecialidadeDto>();        
        }
    }
}