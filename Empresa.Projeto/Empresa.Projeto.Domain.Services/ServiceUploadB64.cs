using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Domain.Services
{
    public class ServiceUploadB64 : ServiceBase<UploadB64>, IServiceUploadB64
    {
        private readonly IRepositoryUploadB64 repositoryUploadB64;

        public ServiceUploadB64(IRepositoryUploadB64 repositoryUploadB64) : base(repositoryUploadB64)
        {
            this.repositoryUploadB64 = repositoryUploadB64;
        }
    }
}
