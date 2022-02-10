using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Services
{
    public class ServiceUnidade : ServiceBase<Unidade>, IServiceUnidade
    {
        private readonly IRepositoryUnidade repositoryUnidade;

        public ServiceUnidade(IRepositoryUnidade repositoryUnidade) : base(repositoryUnidade)
        {
            this.repositoryUnidade = repositoryUnidade;
        }

        public async Task<Unidade> GetByIdDetalhesAsync(long id)
        {
            return await repositoryUnidade.GetByIdDetalhesAsync(id);
        }
    }
}