using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Services
{
    public interface IServiceCapitulo : IServiceBase<Capitulo>
    {
        Task<Capitulo> GetByIdDetalhesAsync(long id);
    }
}
