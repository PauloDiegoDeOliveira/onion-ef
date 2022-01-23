using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly AppContext appContext;

        public RepositoryUsuario(AppContext appContext) : base(appContext)
        {
            this.appContext = appContext;
        }
    }
}