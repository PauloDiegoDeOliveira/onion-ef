using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Services
{
    public class ServiceCapitulo : ServiceBase<Capitulo>, IServiceCapitulo
    {
        private readonly IRepositoryCapitulo repositoryCapitulo;

        public ServiceCapitulo(IRepositoryCapitulo repositoryCapitulo) : base(repositoryCapitulo)
        {
            this.repositoryCapitulo = repositoryCapitulo;
        }

        public async Task<Capitulo> GetByIdDetalhesAsync(long id)
        {
            return await repositoryCapitulo.GetByIdDetalhesAsync(id);
        }
    }
}
