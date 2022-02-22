using AutoMapper;
using Empresa.Projeto.Application.Dtos.UploadB64;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Application.Utilities;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using System;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application
{
    public class ApplicationUploadB64 :
        ApplicationBase<UploadB64, ViewUploadB64Dto, PostUploadB64Dto, PutUploadB64Dto>,
        IApplicationUploadB64
    {
        private readonly IServiceUploadB64 serviceUploadB64;

        public ApplicationUploadB64(IServiceUploadB64 serviceUploadB64,
                                         IMapper mapper) : base(serviceUploadB64, mapper)
        {
            this.serviceUploadB64 = serviceUploadB64;
        }

        public async Task<ViewUploadB64Dto> PostAsync(PostUploadB64Dto postUploadB64, string caminhoAbsoluto, string caminhoRelativo)
        {
            UploadB64 objeto = mapper.Map<UploadB64>(postUploadB64);
            PathCreator pathCreator = new PathCreator();
            objeto.PolulateInformations(pathCreator.CreateAbsolutePath(caminhoAbsoluto), pathCreator.CreateRelativePath(caminhoRelativo));
           
            byte[] imageDataByteArray = Convert.FromBase64String(postUploadB64.ImagemEmBase64);

            B64ImageMethods<UploadB64> uploadClass = new B64ImageMethods<UploadB64>();
            await uploadClass.UploadImagem(objeto.CaminhoAbsoluto, imageDataByteArray);

            return mapper.Map<ViewUploadB64Dto>(await serviceUploadB64.PostAsync(objeto));
        }

        public async Task<ViewUploadB64Dto> PutAsync(PutUploadB64Dto putUploadB64, string caminhoAbsoluto, string caminhoRelativo)
        {
            UploadB64 consulta = await serviceUploadB64.GetByIdAsync(putUploadB64.Id);

            if (consulta is null)
                return null;

            B64ImageMethods<UploadB64> uploadClass = new B64ImageMethods<UploadB64>();
            await uploadClass.DeleteImage(consulta);

            PathCreator pathCreator = new PathCreator();
            consulta.PolulateInformations(pathCreator.CreateAbsolutePath(caminhoAbsoluto), pathCreator.CreateRelativePath(caminhoRelativo));

            byte[] imageDataByteArray = Convert.FromBase64String(putUploadB64.ImagemEmBase64);
            await uploadClass.UploadImagem(consulta.CaminhoAbsoluto, imageDataByteArray);
            return mapper.Map<ViewUploadB64Dto>(await serviceUploadB64.PutAsync(consulta));
        }

        public override async Task<ViewUploadB64Dto> DeleteAsync(long id)
        {
            UploadB64 consulta = await serviceUploadB64.GetByIdAsync(id);

            if (consulta is null)
                return null;

            B64ImageMethods<UploadB64> uploadClass = new B64ImageMethods<UploadB64>();
            await uploadClass.DeleteImage(consulta);

            return await base.DeleteAsync(id);
        }
    }
}