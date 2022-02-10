using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryUnidade : IRepositoryBase<Unidade>
    {
        Task<Unidade> GetByIdDetalhesAsync(long id);
    }
}
