using AutoMapper;
using Empresa.Projeto.Application.Dtos.UploadForm;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Application.Utilities;
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

            PathCreator pathCreator = new PathCreator();
            objeto.PolulateInformations(objeto, pathCreator.CreateAbsolutePath(caminhoAbsoluto), pathCreator.CreateRelativePath(caminhoRelativo));
            
            FormImageMethods<UploadForm> uploadClass = new FormImageMethods<UploadForm>();
            await uploadClass.UploadImage(objeto);
            
            return mapper.Map<ViewUploadFormDto>(await serviceUploadForm.PostAsync(objeto));
        }

        public async Task<ViewUploadFormDto> PutAsync(PutUploadFormDto putUploadForm, string caminhoAbsoluto, string caminhoRelativo)
        {
            UploadForm consulta = await serviceUploadForm.GetByIdAsync(putUploadForm.Id);

            if (consulta is null)
                return null;

            FormImageMethods<UploadForm> uploadClass = new FormImageMethods<UploadForm>();
            await uploadClass.DeleteImage(consulta);

            PathCreator pathCreator = new PathCreator();
            consulta.PolulateInformations(mapper.Map<UploadForm>(putUploadForm), pathCreator.CreateAbsolutePath(caminhoAbsoluto), pathCreator.CreateRelativePath(caminhoRelativo));
            
            await uploadClass.UploadImage(consulta);
            return mapper.Map<ViewUploadFormDto>(await serviceUploadForm.PutAsync(consulta));
        }

        public override async Task<ViewUploadFormDto> DeleteAsync(long id)
        {
            UploadForm consulta = await serviceUploadForm.GetByIdAsync(id);

            if (consulta is null)
                return null;

            FormImageMethods<UploadForm> uploadClass = new FormImageMethods<UploadForm>();
            await uploadClass.DeleteImage(consulta);
            return await base.DeleteAsync(id);
        }
    }
}