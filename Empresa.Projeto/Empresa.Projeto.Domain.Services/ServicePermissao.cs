using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Pagination;
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

        public async Task<PagedList<Permissao>> GetPaginationAsync(ParametersBase parametersBase)
        {
            return await repositoryPermissao.GetPaginationAsync(parametersBase);
        }

        public async Task<Permissao> GetByIdDetalhesAsync(long id)
        {
            return await repositoryPermissao.GetByIdDetalhesAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await repositoryPermissao.SaveChangesAsync();
        }
    }
}