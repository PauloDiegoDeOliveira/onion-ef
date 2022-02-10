using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Services
{
    public interface IServiceUnidade : IServiceBase<Unidade>
    {
        Task<Unidade> GetByIdDetalhesAsync(long id);
    }
}
