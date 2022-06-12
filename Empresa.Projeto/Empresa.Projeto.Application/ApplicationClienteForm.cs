using AutoMapper;
using Empresa.Projeto.Application.Dtos.ClienteForm;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;
using Empresa.Projeto.Application.Utilities;

namespace Empresa.Projeto.Application
{
    public class ApplicationClienteForm :
        ApplicationBase<ClienteForm, ViewClienteFormDto, PostClienteFormDto, PutClienteFormDto>,
        IApplicationClienteForm
    {
        private readonly IServiceClienteForm serviceClienteForm;
        public ApplicationClienteForm(IServiceClienteForm serviceClienteForm, IMapper mapper) : base(serviceClienteForm, mapper)
        {
            this.serviceClienteForm = serviceClienteForm;
        }

        public async Task<ViewClienteFormDto> PostAsync(PostClienteFormDto postClienteFormDto, string caminhoAbsoluto, string caminhoRelativo)
        {
            ClienteForm objeto = mapper.Map<ClienteForm>(postClienteFormDto);
            PathCreator pathCreator = new PathCreator();
            objeto.PolulateInformations(objeto, pathCreator.CreateAbsolutePath(caminhoAbsoluto), pathCreator.CreateRelativePath(caminhoRelativo));
            
            FormImageMethods<ClienteForm> uploadClass = new FormImageMethods<ClienteForm>();
            await uploadClass.UploadImage(objeto);

            return mapper.Map<ViewClienteFormDto>(await serviceClienteForm.PostAsync(objeto));
        }

        public async Task<ViewClienteFormDto> PutAsync(PutClienteFormDto putClienteFormDto, string caminhoAbsoluto, string caminhoRelativo)
        {
            ClienteForm consulta = await serviceClienteForm.GetByIdAsync(putClienteFormDto.Id);
            if (consulta is null)
                return null;

            FormImageMethods<ClienteForm> uploadClass = new FormImageMethods<ClienteForm>();
            await uploadClass.DeleteImage(consulta);

            PathCreator pathCreator = new PathCreator();
            consulta.PolulateInformations(mapper.Map<ClienteForm>(putClienteFormDto), pathCreator.CreateAbsolutePath(caminhoAbsoluto), pathCreator.CreateRelativePath(caminhoRelativo));
            
            await uploadClass.UploadImage(consulta);
            return mapper.Map<ViewClienteFormDto>(await serviceClienteForm.PutAsync(consulta));
        }

        public override async Task<ViewClienteFormDto> DeleteAsync(long id)
        {
            ClienteForm consulta = await serviceClienteForm.GetByIdAsync(id);

            if (consulta is null)
                return null;

            FormImageMethods<ClienteForm> uploadClass = new FormImageMethods<ClienteForm>();
            await uploadClass.DeleteImage(consulta);
            return await base.DeleteAsync(id);
        }
    }
}