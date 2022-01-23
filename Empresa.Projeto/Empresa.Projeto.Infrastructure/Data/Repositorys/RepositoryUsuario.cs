using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly AppDbContext appContext;

        public RepositoryUsuario(AppDbContext appContext) : base(appContext)
        {
            this.appContext = appContext;
        }
    }
}