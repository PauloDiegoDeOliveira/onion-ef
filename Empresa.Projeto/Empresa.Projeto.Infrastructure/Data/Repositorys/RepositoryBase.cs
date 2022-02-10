using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        private readonly AppDbContext appDbContext;

        public RepositoryBase(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await appDbContext.Set<TEntity>().Where(p => p.Status != (int)Status.Excluido).AsNoTracking().ToListAsync();
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
            obj.ChangeAlteradoEmValue(DateTime.Now);
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

        public virtual async Task<bool> ExisteNaBaseAsync(long? id)
        {
            return await appDbContext.Set<TEntity>().AnyAsync(x => x.Id == id);
        }
    }
}