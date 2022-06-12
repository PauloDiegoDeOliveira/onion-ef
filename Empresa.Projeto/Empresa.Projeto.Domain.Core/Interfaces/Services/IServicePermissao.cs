using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Services
{
    public interface IServicePermissao : IServiceBase<Permissao>
    {
        Task<PagedList<Permissao>> GetPaginationAsync(ParametersBase parametersBase);
        Task<Permissao> GetByIdDetalhesAsync(long id);
        Task SaveChangesAsync();
    }
}