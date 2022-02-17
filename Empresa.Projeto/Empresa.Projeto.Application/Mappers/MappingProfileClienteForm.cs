using AutoMapper;
using Empresa.Projeto.Application.Dtos.ClienteForm;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application.Mappers
{
    public class MappingProfileClienteForm : Profile
    {
        public MappingProfileClienteForm()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<ClienteForm, PostClienteFormDto>().ReverseMap();
            CreateMap<PutClienteFormDto, ClienteForm>();
            CreateMap<ClienteForm, ViewClienteFormDto>();
        }
    }
}
