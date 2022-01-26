using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        private readonly AppDbContext appDbContext;

        public RepositoryBase(AppDbContext appContext)
        {
            this.appDbContext = appContext;
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await appDbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await appDbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<TEntity> PostAsync(TEntity obj)
        {
            appDbContext.Set<TEntity>().Add(obj);
            await appDbContext.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<TEntity> PutAsync(TEntity obj)
        {
            appDbContext.Entry(obj).State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<TEntity> DeleteAsync(long id)
        {
            var obj = await GetByIdAsync(id);
            if (obj != null)
            {
                appDbContext.Remove(obj);
                await appDbContext.SaveChangesAsync();
            }
            return obj;
        }
    }
}