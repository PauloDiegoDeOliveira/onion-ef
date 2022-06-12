using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Services
{
    public class ServiceBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            this.repositoryBase = repositoryBase;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repositoryBase.GetAllAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await repositoryBase.GetByIdAsync(id);
        }

        public virtual async Task<TEntity> PostAsync(TEntity obj)
        {
            return await repositoryBase.PostAsync(obj);
        }

        public virtual async Task<TEntity> PutAsync(TEntity obj)
        {
            return await repositoryBase.PutAsync(obj);
        }

        public virtual async Task<TEntity> DeleteAsync(long id)
        {
            return await repositoryBase.DeleteAsync(id);
        }

        public async Task<TEntity> PutStatusAsync(TEntity obj)
        {
            return await repositoryBase.PutAsync(obj);
        }

        public virtual async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await repositoryBase.ExisteNaBaseAsync(id);
        }
    }
}