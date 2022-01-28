using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Core.Interfaces.Repositorys
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(long id);

        Task<TEntity> PostAsync(TEntity obj);

        Task<TEntity> PutAsync(TEntity obj);

        Task<TEntity> DeleteAsync(long id);
    }
}