using Empresa.Projeto.Application.Dtos.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        Task<IEnumerable<ViewUsuarioDto>> GetAllAsync();
    }
}