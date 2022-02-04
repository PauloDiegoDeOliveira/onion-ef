using Empresa.Projeto.Application.Dtos.Paginacao;
using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Application.Structs;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Enums;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationPermissao : IApplicationBase<ViewPermissaoDto, PostPermissaoDto, PutPermissaoDto>
    {
        Task<PermissaoPagination> GetAllPaginationAsync(int pageNumber, int resultSize);

        Task<ViewPermissaoUsuarioDto> GetByIdDetalhesAsync(long id);

        Task<EntityDtoStruct<Permissao, PutPermissaoDto>> GetByIdReturnPutAsync(long id);

        Task<ViewPermissaoDto> PutStatusAsync(long id, Status status);

        Task SaveChangesAsync(EntityDtoStruct<Permissao, PutPermissaoDto> dtoStruct);

        Task<bool> ExisteNaBaseAsync(long? id);
    }
}