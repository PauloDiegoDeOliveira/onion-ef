using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryClienteForm : RepositoryBase<ClienteForm>, IRepositoryClienteForm
    {
        private readonly AppDbContext appDbContext;

        public RepositoryClienteForm(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}
