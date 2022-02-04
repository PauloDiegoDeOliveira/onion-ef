using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryUploadForm : RepositoryBase<UploadForm>, IRepositoryUploadForm
    {
        private readonly AppDbContext appDbContext;

        public RepositoryUploadForm(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}