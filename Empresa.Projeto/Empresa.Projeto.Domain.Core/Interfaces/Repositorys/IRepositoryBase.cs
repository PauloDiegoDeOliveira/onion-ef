using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(long id);

        Task<TEntity> PostAsync(TEntity obj);

        Task<TEntity> PutAsync(TEntity obj);

        Task<TEntity> DeleteAsync(long id);

        Task<bool> ExisteNaBaseAsync(long? id);
    }
}