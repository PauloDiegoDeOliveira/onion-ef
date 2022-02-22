using AutoMapper;
using Empresa.Projeto.Application.Dtos.AlunoB64;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Application.Utilities;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using System;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application
{
    public class ApplicationAlunoB64 :
        ApplicationBase<AlunoB64, ViewAlunoB64Dto, PostAlunoB64Dto, PutAlunoB64Dto>,
        IApplicationAlunoB64
    {
        private readonly IServiceAlunoB64 serviceAlunoB64;

        public ApplicationAlunoB64(IServiceAlunoB64 serviceAlunoB64,
                                         IMapper mapper) : base(serviceAlunoB64, mapper)
        {
            this.serviceAlunoB64 = serviceAlunoB64;
        }

        public async Task<ViewAlunoB64Dto> PostAsync(PostAlunoB64Dto postAlunob64, string caminhoAbsoluto, string caminhoRelativo)
        {
            AlunoB64 objeto = mapper.Map<AlunoB64>(postAlunob64);
            PathCreator pathCreator = new PathCreator();
            objeto.PolulateInformations(pathCreator.CreateAbsolutePath(caminhoAbsoluto), pathCreator.CreateRelativePath(caminhoRelativo));

            byte[] imageDataByteArray = Convert.FromBase64String(postAlunob64.ImagemEmBase64);

            B64ImageMethods<AlunoB64> uploadClass = new B64ImageMethods<AlunoB64>();
            await uploadClass.UploadImagem(objeto.CaminhoAbsoluto, imageDataByteArray);

            return mapper.Map<ViewAlunoB64Dto>(await serviceAlunoB64.PostAsync(objeto));
        }

        public async Task<ViewAlunoB64Dto> PutAsync(PutAlunoB64Dto putAlunoB64, string caminhoAbsoluto, string caminhoRelativo)
        {
            AlunoB64 consulta = await serviceAlunoB64.GetByIdAsync(putAlunoB64.Id);

            if (consulta is null)
                return null;

            B64ImageMethods<AlunoB64> uploadClass = new B64ImageMethods<AlunoB64>();
            await uploadClass.DeleteImage(consulta);

            PathCreator pathCreator = new PathCreator();
            consulta.PolulateInformations(pathCreator.CreateAbsolutePath(caminhoAbsoluto), pathCreator.CreateRelativePath(caminhoRelativo));

            byte[] imageDataByteArray = Convert.FromBase64String(putAlunoB64.ImagemEmBase64);
            await uploadClass.UploadImagem(consulta.CaminhoAbsoluto, imageDataByteArray);
            return mapper.Map<ViewAlunoB64Dto>(await serviceAlunoB64.PutAsync(consulta));
        }

        public override async Task<ViewAlunoB64Dto> DeleteAsync(long id)
        {
            AlunoB64 consulta = await serviceAlunoB64.GetByIdAsync(id);

            if (consulta is null)
                return null;

            B64ImageMethods<AlunoB64> uploadClass = new B64ImageMethods<AlunoB64>();
            await uploadClass.DeleteImage(consulta);

            return await base.DeleteAsync(id);
        }
    }
}
