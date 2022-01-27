using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Services
{
    public interface IServicePermissao : IServiceBase<Permissao>
    {
        Task<Permissao> PutStatusAsync(Permissao permissao);
        Task<Permissao> GetByIdUsuarioAsync(long id);
    }
}
