using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryPermissao : IServiceBase<Permissao>
    {
        Task<Permissao> PutStatusAsync(Permissao permissao);

        Task<Permissao> GetByIdPermissaoAsync(long id);

        Task<bool> SaveChangesAsync();
    }
}