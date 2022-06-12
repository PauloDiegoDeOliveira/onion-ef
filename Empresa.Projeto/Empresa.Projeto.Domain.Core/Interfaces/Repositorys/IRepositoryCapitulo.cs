using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryCapitulo : IRepositoryBase<Capitulo>
    {
        Task<Capitulo> GetByIdDetalhesAsync(long id);
    }
}
