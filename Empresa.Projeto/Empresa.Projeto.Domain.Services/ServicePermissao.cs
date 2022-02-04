using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Permissao>> GetPaginationAsync(int pageNumber, int resultSize)
        {
            return await repositoryPermissao.GetPaginationAsync(pageNumber, resultSize);
        }

        public async Task<Permissao> GetByIdDetalhesAsync(long id)
        {
            return await repositoryPermissao.GetByIdDetalhesAsync(id);
        }

        public async Task<int> GetCountAsync()
        {
            return await repositoryPermissao.GetCountAsync();
        }

        public async Task SaveChangesAsync()
        {
            await repositoryPermissao.SaveChangesAsync();
        }
    }
}