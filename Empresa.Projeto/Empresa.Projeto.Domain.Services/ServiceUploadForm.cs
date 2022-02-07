using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Domain.Services
{
    public class ServiceUploadForm : ServiceBase<UploadForm>, IServiceUploadForm
    {
        private readonly IRepositoryUploadForm repositoryUploadForm;

        public ServiceUploadForm(IRepositoryUploadForm repositoryUploadForm) : base(repositoryUploadForm)
        {
            this.repositoryUploadForm = repositoryUploadForm;
        }
    }
}