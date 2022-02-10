using Empresa.Projeto.Application.Adaptatives;
using Empresa.Projeto.Application.Dtos.Capitulo;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationCapitulo : IApplicationBase<ViewCapituloDto, PostCapituloDto, PutCapituloDto>
    {
        Task<CapituloAdaptative> GetByIdDetalhesAdaptativeAsync(long id);
    }
}
