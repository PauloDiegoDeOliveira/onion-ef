using Empresa.Projeto.Application.Dtos.Correios;
using Refit;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationServiceCorreios
    {
        [Get("/ws/{cep}/json/")]
        Task<ViewCorreiosDto> GetCep(string cep);
    }
}
