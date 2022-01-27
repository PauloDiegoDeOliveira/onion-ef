using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationServicePermissao : 
        IApplicationServiceBase<ViewPermissaoDto, PostPermissaoDto, PutPermissaoDto>
    {
        Task<ViewPermissaoDto> PutStatusAsync(long id);
        Task<Permissao> GetByIdPermissaoAsync(long id);
        Task<int?> SaveChangesAsync(long id);
    }
}
