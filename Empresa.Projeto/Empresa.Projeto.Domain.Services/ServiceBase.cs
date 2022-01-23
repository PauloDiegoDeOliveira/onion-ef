using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await repository.GetByIdAsync(id);
        }

        public virtual async Task<TEntity> PostAsync(TEntity obj)
        {
            return await repository.PostAsync(obj);
        }

        public virtual async Task<TEntity> PutAsync(TEntity obj)
        {
            return await repository.PutAsync(obj); 
        }

        public async Task<TEntity> DeleteAsync(long id) 
        {
            return await repository.DeleteAsync(id); 
        }
    }
}