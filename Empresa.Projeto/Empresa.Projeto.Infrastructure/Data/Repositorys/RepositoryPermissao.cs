using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Pagination;
using Microsoft.EntityFrameworkCore;
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

        public async Task<PagedList<Permissao>> GetPaginationAsync(ParametersBase parametersBase)
        {
            return await Task.FromResult(PagedList<Permissao>
                .ToPagedList(appDbContext.Permissoes
                .OrderBy(on => on.Id)
                .Where(x => EF.Functions.Like(x.Nome, $"%{parametersBase.PalavraChave}%"))
                .Where(x => (int)parametersBase.Status == 0 ? true : x.Status == (int)parametersBase.Status)
                .Where(x => parametersBase.Id == 0 || x.Id == parametersBase.Id),
                 parametersBase.NumeroPagina, parametersBase.ResultadosExibidos));
        }

        public async Task<Permissao> GetByIdDetalhesAsync(long id)
        {
            var obj = await appDbContext.Permissoes
                .Include(x => x.Usuarios)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return obj;
        }

        public async Task SaveChangesAsync()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}