using Empresa.Projeto.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Services
{
    public interface IServicePermissao : IServiceBase<Permissao>
    {
        Task<IEnumerable<Permissao>> GetPaginationAsync(int pageNumber, int resultSize);
        Task<Permissao> GetByIdDetalhesAsync(long id);
        Task<int> GetCountAsync();
        Task SaveChangesAsync();
    }
}