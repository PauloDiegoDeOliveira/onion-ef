using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;

using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Services
{
    public class ServicePermissao : ServiceBase<Permissao>, IServicePermissao
    {
        private readonly IRepositoryPermissao repositoryPermissao;

        public ServicePermissao(IRepositoryPermissao repositoryPermissao) : base(repositoryPermissao)
        {
            this.repositoryPermissao = repositoryPermissao;
        }

        public async Task<Permissao> PutStatusAsync(Permissao permissao)
        {
            return await repositoryPermissao.PutStatusAsync(permissao);
        }

        public async Task<Permissao> GetByIdPermissaoAsync(long id)
        {
            return await repositoryPermissao.GetByIdPermissaoAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await repositoryPermissao.SaveChangesAsync();
        }
    }
}