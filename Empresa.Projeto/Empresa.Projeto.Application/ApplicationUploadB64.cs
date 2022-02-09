using AutoMapper;
using Empresa.Projeto.Application.Dtos.UploadB64;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using System;
using System.IO;
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
            byte[] imageDataByteArray = Convert.FromBase64String(postUploadB64.ImagemEmBase64);
            objeto.PolulateInformations(caminhoRelativo, caminhoAbsoluto);
            await UploadImagem(objeto.CaminhoAbsoluto, imageDataByteArray);

            return mapper.Map<ViewUploadB64Dto>(await serviceUploadB64.PostAsync(objeto));
        }

        public async Task<ViewUploadB64Dto> PutAsync(PutUploadB64Dto putUploadB64, string caminhoAbsoluto, string caminhoRelativo)
        {
            UploadB64 consulta = await serviceUploadB64.GetByIdAsync(putUploadB64.Id);

            if (consulta is null)
                return null;

            await DeleteImage(consulta);

            byte[] imageDataByteArray = Convert.FromBase64String(putUploadB64.ImagemEmBase64);

            consulta.PolulateInformations(caminhoRelativo, caminhoAbsoluto);
            await UploadImagem(consulta.CaminhoAbsoluto, imageDataByteArray);
            return mapper.Map<ViewUploadB64Dto>(await serviceUploadB64.PutAsync(consulta));
        }

        public override async Task<ViewUploadB64Dto> DeleteAsync(long id)
        {
            UploadB64 consulta = await serviceUploadB64.GetByIdAsync(id);

            if (consulta is null)
                return null;

            await DeleteImage(consulta);
            return await base.DeleteAsync(id);
        }

        private async Task UploadImagem(string caminho, byte[] imageDataByteArray)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), caminho);
            await File.WriteAllBytesAsync(filePath, imageDataByteArray);
        }

        private async Task DeleteImage(UploadB64 uploadB64)
        {
            if (File.Exists(uploadB64.CaminhoAbsoluto))
            {
                File.Delete(uploadB64.CaminhoAbsoluto);
            }
            await Task.CompletedTask;
        }
    }
}