using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationUsuario :
        IApplicationBase<ViewUsuarioDto, PostUsuarioDto, PutUsuarioDto>
    {
        Task<IList<ViewUsuarioDto>> GetNomeAsync(string nome);
        Task<ViewAposAutenticacaoDto> AutenticacaoAsync(ViewPreAutenticacaoDto viewPreAutenticacao);
        Task<ViewUsuarioDto> PutStatusAsync(long id, Status status);
        Task<ViewUsuarioPermissaoDto> GetByIdDetalhesAsync(long id);  
    }
}