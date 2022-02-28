using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Application.Structs;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationPermissao : IApplicationBase<ViewPermissaoDto, PostPermissaoDto, PutPermissaoDto>
    {
        Task<ViewPaginationPermissaoDto> GetPaginationAsync(ParametersBase parametersBase);

        Task<ViewPermissaoUsuarioDto> GetByIdDetalhesAsync(long id);

        Task<EntityDtoStruct<Permissao, PutPermissaoDto>> GetByIdReturnStructDtoAsync(long id);

        Task SaveChangesAsync(EntityDtoStruct<Permissao, PutPermissaoDto> dtoStruct);
    }
}