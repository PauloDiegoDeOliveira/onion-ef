using AutoMapper;
using Empresa.Projeto.Application.Dtos.UploadB64;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Application.Mappers
{
    public class MappingProfileUploadB64 : Profile
    {
        public MappingProfileUploadB64()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<PostUploadB64Dto, UploadB64>();
            CreateMap<PutUploadB64Dto, UploadB64>();
            CreateMap<UploadB64, ViewUploadB64Dto>();
        }
    }
}
