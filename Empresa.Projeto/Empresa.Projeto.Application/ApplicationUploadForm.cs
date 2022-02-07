using AutoMapper;
using Empresa.Projeto.Application.Dtos.UploadForm;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using System.IO;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application
{
    public class ApplicationUploadForm :
        ApplicationBase<UploadForm, ViewUploadFormDto, PostUploadFormDto, PutUploadFormDto>,
        IApplicationUploadForm
    {
        private readonly IServiceUploadForm serviceUploadForm;

        public ApplicationUploadForm(IServiceUploadForm serviceUploadForm,
                                         IMapper mapper) : base(serviceUploadForm, mapper)
        {
            this.serviceUploadForm = serviceUploadForm;
        }

        public async Task<ViewUploadFormDto> PostAsync(PostUploadFormDto postUploadForm, string caminhoAbsoluto, string caminhoRelativo)
        {
            UploadForm objeto = mapper.Map<UploadForm>(postUploadForm);
            objeto.PolulateInformations(objeto, caminhoRelativo, caminhoAbsoluto);
            await UploadImage(objeto);
            return mapper.Map<ViewUploadFormDto>(await serviceUploadForm.PostAsync(objeto));
        }

        public async Task<ViewUploadFormDto> PutAsync(PutUploadFormDto putUploadForm, string caminhoAbsoluto, string caminhoRelativo)
        {
            UploadForm consulta = await serviceUploadForm.GetByIdAsync(putUploadForm.Id);

            if (consulta is null)
                return null;

            await DeleteImage(consulta);

            consulta.PolulateInformations(mapper.Map<UploadForm>(putUploadForm), caminhoRelativo, caminhoAbsoluto);
            await UploadImage(consulta);
            return mapper.Map<ViewUploadFormDto>(await serviceUploadForm.PutAsync(consulta));
        }

        public override async Task<ViewUploadFormDto> DeleteAsync(long id)
        {
            UploadForm consulta = await serviceUploadForm.GetByIdAsync(id);

            if (consulta is null)
                return null;

            await DeleteImage(consulta);
            return await base.DeleteAsync(id);
        }

        private async Task UploadImage(UploadForm uploadForm)
        {
            string root = Path.Combine(Directory.GetCurrentDirectory(), uploadForm.CaminhoAbsoluto);
            using (var stream = new FileStream(root, FileMode.Create))
            {
                await uploadForm.ImagemUpload.CopyToAsync(stream);
            }
        }

        private async Task DeleteImage(UploadForm uploadForm)
        {
            if (File.Exists(uploadForm.CaminhoAbsoluto))
            {
                File.Delete(uploadForm.CaminhoAbsoluto);
            }
            await Task.CompletedTask;
        }
    }
}