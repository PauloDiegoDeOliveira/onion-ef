using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryAlunoB64 : RepositoryBase<AlunoB64>, IRepositoryAlunoB64
    {
        private readonly AppDbContext appDbContext;

        public RepositoryAlunoB64(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}
