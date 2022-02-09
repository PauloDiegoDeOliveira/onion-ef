using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryUploadB64 : RepositoryBase<UploadB64>, IRepositoryUploadB64
    {
        private readonly AppDbContext appDbContext;

        public RepositoryUploadB64(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}
