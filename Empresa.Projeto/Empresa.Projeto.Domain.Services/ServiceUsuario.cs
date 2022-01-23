using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Domain.Services
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario repositoryUsuario;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario) : base(repositoryUsuario)
        {
            this.repositoryUsuario = repositoryUsuario;
        }
    }
}