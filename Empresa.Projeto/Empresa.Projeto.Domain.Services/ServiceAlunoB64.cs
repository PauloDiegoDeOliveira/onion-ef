using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Domain.Services
{
    public class ServiceAlunoB64 : ServiceBase<AlunoB64>, IServiceAlunoB64
    {
        private readonly IRepositoryAlunoB64 repositoryAlunoB64;

        public ServiceAlunoB64(IRepositoryAlunoB64 repositoryAlunoB64) : base(repositoryAlunoB64)
        {
            this.repositoryAlunoB64 = repositoryAlunoB64;
        }
    }
}
