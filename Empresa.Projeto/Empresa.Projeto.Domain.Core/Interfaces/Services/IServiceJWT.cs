using Empresa.Projeto.Domain.Entitys;

namespace Empresa.Projeto.Domain.Core.Interfaces.Services
{
    public interface IServiceJWT
    {
        string GerarToken(Usuario usuario);
    }
}