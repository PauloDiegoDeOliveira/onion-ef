using Empresa.Projeto.Application.Dtos.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        Task<IList<ViewUsuarioDto>> GetAllAsync();
        Task<ViewUsuarioDto> GetByIdAsync(long id);
        Task<ViewUsuarioDto> PostAsync(PostUsuarioDto post);
        Task<ViewUsuarioDto> PutAsync(PutUsuarioDto put);
        Task<ViewUsuarioDto> DeleteAsync(long id);
        Task<IList<ViewUsuarioDto>> GetNomeAsync(string nome); 
        Task<ViewAposAutenticacaoDto> AutenticacaoAsync(ViewPreAutenticacaoDto viewPreAutenticacao);
    }
}