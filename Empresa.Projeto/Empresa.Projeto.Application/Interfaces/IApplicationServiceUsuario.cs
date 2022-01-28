using Empresa.Projeto.Application.Dtos.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationServiceUsuario :
        IApplicationServiceBase<ViewUsuarioDto, PostUsuarioDto, PutUsuarioDto>
    {
        Task<IList<ViewUsuarioDto>> GetNomeAsync(string nome);

        Task<ViewAposAutenticacaoDto> AutenticacaoAsync(ViewPreAutenticacaoDto viewPreAutenticacao);

        Task<ViewUsuarioDto> PutStatusAsync(long id);
    }
}