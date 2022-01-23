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
    }
}