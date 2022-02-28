using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;
using Empresa.Projeto.Domain.Pagination;

namespace Empresa.Projeto.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryPermissao : IRepositoryBase<Permissao>
    {
        Task<PagedList<Permissao>> GetPaginationAsync(ParametersBase parametersBase);
        Task<Permissao> GetByIdDetalhesAsync(long id);
        Task SaveChangesAsync();
    }
}