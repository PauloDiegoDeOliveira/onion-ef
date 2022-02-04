using AutoMapper;
using Empresa.Projeto.Application.Dtos.UploadForm;
using Empresa.Projeto.Domain.Entitys;
using System;

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
            CreateMap<PutUploadFormDto, UploadForm>().ForMember(d => d.AlteradoEm, o => o.MapFrom(x => DateTime.Now)).ReverseMap();
            CreateMap<UploadForm, ViewUploadFormDto>();
        }
    }
}