using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryPermissao : RepositoryBase<Permissao>, IRepositoryPermissao
    {
        private readonly AppDbContext appDbContext;

        public RepositoryPermissao(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Permissao>> GetPaginationAsync(int pageNumber, int resultSize)
        {
            return await appDbContext.Set<Permissao>().Where(p => p.Status != (int)Status.Excluido).AsNoTracking().Skip((pageNumber - 1) * resultSize).Take(resultSize).ToListAsync();
        }

        public async Task<Permissao> GetByIdDetalhesAsync(long id)
        {
            var obj = await appDbContext.Permissoes
                .Include(x => x.Usuarios)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return obj;
        }

        public async Task<int> GetCountAsync()
        {
            return await appDbContext.Set<Permissao>().Where(p => p.Status != (int)Status.Excluido).AsNoTracking().CountAsync();
        }

        public async Task SaveChangesAsync()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}