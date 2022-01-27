using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Services
{
    public class ServiceBase<TEntity> : Core.Interfaces.Services.IServiceBase<TEntity> where TEntity : class
    {
        private readonly Core.Interfaces.Repositorys.IServiceBase<TEntity> repositoryBase;

        public ServiceBase(Core.Interfaces.Repositorys.IServiceBase<TEntity> repositoryBase)
        {
            this.repositoryBase = repositoryBase;
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await repositoryBase.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(long id)
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

        public async Task<TEntity> DeleteAsync(long id) 
        {
            return await repositoryBase.DeleteAsync(id); 
        }
    }
}