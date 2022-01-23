using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DbContext appContext;

        public RepositoryBase(DbContext appContext)
        {
            this.appContext = appContext;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await appContext.Set<TEntity>()
                                   .AsNoTracking()
                                   .ToListAsync();
        }
    }
}