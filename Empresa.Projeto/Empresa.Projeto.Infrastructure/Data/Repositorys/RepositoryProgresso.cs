using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryProgresso : RepositoryBase<Progresso>, IRepositoryProgresso
    {
        private readonly AppDbContext appDbContext;

        public RepositoryProgresso(AppDbContext appContext) : base(appContext)
        {
            this.appDbContext = appContext;
        }
    }
}
