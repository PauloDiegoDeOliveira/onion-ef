using Empresa.Projeto.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        Task<IList<Usuario>> GetNomeAsync(string nome);
        Task<Usuario> GetEmailAsync(string email);
        Task<Usuario> GetByIdDetalhesAsync(long id);
        Task<Usuario> InsertEspecialidadesAsync(Usuario usuario);
        Task<Usuario> PutUltimoAcessoAsync(Usuario usuario);
    }
}