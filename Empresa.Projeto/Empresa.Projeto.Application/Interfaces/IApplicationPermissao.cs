using Empresa.Projeto.Application.Dtos.Paginacao;
using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Application.Structs;
using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationPermissao : IApplicationBase<ViewPermissaoDto, PostPermissaoDto, PutPermissaoDto>
    {
        Task<PermissaoPagination> GetPaginationAsync(int pageNumber, int resultSize);

        Task<ViewPermissaoUsuarioDto> GetByIdDetalhesAsync(long id);

        Task<EntityDtoStruct<Permissao, PutPermissaoDto>> GetByIdReturnStructDtoAsync(long id);

        Task SaveChangesAsync(EntityDtoStruct<Permissao, PutPermissaoDto> dtoStruct);
    }
}