using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryPermissao : RepositoryBase<Permissao>, IRepositoryPermissao
    {
        private readonly AppDbContext appDbContext;

        public RepositoryPermissao(AppDbContext appContext) : base(appContext)
        {
            this.appDbContext = appContext;
        }

        public async Task<Permissao> PutStatusAsync(Permissao permissao)
        {
            appDbContext.Permissoes.Update(permissao);
            await appDbContext.SaveChangesAsync();
            return permissao;
        }

        public async Task<Permissao> GetByIdPermissaoAsync(long id)
        {
            Permissao obj = await GetByIdAsync(id);
            return obj;
        }

        public async Task SaveChangesAsync()
        {
            await appDbContext.SaveChangesAsync();
        }

        public async Task<Permissao> GetByIdDetalhesAsync(long id)
        {
            var obj = await appDbContext.Permissoes
                .Include(x => x.Usuarios)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return obj;
        }
    }
}