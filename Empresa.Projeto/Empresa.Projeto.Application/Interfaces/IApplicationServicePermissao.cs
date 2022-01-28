using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Enums;
using System.Threading.Tasks;

public struct ObjetoPermissao
{
    public PutPermissaoDto putPermissaoDto;
    public Permissao permissao;
}

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationServicePermissao :
        IApplicationServiceBase<ViewPermissaoDto, PostPermissaoDto, PutPermissaoDto>
    {
        Task<ViewPermissaoDto> PutStatusAsync(long id, Status status);

        Task<ObjetoPermissao> GetByIdReturnPutAsync(long id);

        Task<bool> SaveChangesAsync(PutPermissaoDto putPermissaoDto, Permissao permissao);
    }
}