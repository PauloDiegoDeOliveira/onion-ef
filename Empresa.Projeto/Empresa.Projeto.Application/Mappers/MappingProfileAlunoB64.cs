using AutoMapper;
using Empresa.Projeto.Application.Dtos.AlunoB64;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application.Mappers
{
    public class MappingProfileAlunoB64 : Profile
    {
        public MappingProfileAlunoB64()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<PostAlunoB64Dto, AlunoB64>();
            CreateMap<PutAlunoB64Dto, AlunoB64>();
            CreateMap<AlunoB64, ViewAlunoB64Dto>();
        }
    }
}
