using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Domain.Services
{
    public class ServiceEspecialidade : ServiceBase<Especialidade>, IServiceEspecialidade
    {
        private readonly IRepositoryEspecialidade repositoryEspecialidade;

        public ServiceEspecialidade(IRepositoryEspecialidade repositoryEspecialidade) : base(repositoryEspecialidade)
        {
            this.repositoryEspecialidade = repositoryEspecialidade;
        }
    }
}
