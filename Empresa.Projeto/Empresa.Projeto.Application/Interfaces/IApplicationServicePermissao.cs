using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Application.Structs;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Enums;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationServicePermissao :
        IApplicationServiceBase<ViewPermissaoDto, PostPermissaoDto, PutPermissaoDto>
    {
        Task<ViewPermissaoDto> PutStatusAsync(long id, Status status);

        Task<EntityDtoStruct<Permissao, PutPermissaoDto>> GetByIdReturnPutAsync(long id);

        Task SaveChangesAsync(EntityDtoStruct<Permissao, PutPermissaoDto> dtoStruct);

        Task<ViewPermissaoUsuarioDto> GetByIdDetalhesAsync(long id);
    }
}