using AutoMapper;
using Empresa.Projeto.Application.Dtos.UploadForm;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application.Mappers
{
    public class MappingProfileUploadForm : Profile
    {
        public MappingProfileUploadForm()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<UploadForm, PostUploadFormDto>().ReverseMap();
            CreateMap<PutUploadFormDto, UploadForm>();
            CreateMap<UploadForm, ViewUploadFormDto>();
        }
    }
}