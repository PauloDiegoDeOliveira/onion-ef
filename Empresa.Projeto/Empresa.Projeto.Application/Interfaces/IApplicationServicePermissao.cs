using Empresa.Projeto.Application.Dtos.Permissao;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationServicePermissao : 
        IApplicationServiceBase<ViewPermissaoDto, PostPermissaoDto, PutPermissaoDto>
    {
        Task<ViewPermissaoDto> PutStatusAsync(long id);
    }
}
