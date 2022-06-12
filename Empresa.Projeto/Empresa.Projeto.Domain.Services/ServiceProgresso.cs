using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Domain.Services
{
    public class ServiceProgresso : ServiceBase<Progresso>, IServiceProgresso
    {
        private readonly IRepositoryProgresso repositoryProgresso;

        public ServiceProgresso(IRepositoryProgresso repositoryProgresso) : base(repositoryProgresso)
        {
            this.repositoryProgresso = repositoryProgresso;
        }
    }
}
