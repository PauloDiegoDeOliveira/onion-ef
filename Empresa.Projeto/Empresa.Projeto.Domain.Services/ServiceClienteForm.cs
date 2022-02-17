using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Domain.Services
{
    public class ServiceClienteForm : ServiceBase<ClienteForm>, IServiceClienteForm
    {
        private readonly IRepositoryClienteForm repositoryClienteForm;

        public ServiceClienteForm(IRepositoryClienteForm repositoryClienteForm) : base(repositoryClienteForm)
        {
            this.repositoryClienteForm = repositoryClienteForm;
        }
    }
}
