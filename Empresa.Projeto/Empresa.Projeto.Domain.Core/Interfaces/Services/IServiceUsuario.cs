using Empresa.Projeto.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        Task<IList<Usuario>> GetNomeAsync(string nome);

        Task<Usuario> GetEmailAsync(string email);

        Task<Usuario> PutStatusAsync(Usuario usuario);

        Task<Usuario> GetByIdUsuarioAsync(long id);
    }
}