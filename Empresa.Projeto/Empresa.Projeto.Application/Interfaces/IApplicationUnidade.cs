using Empresa.Projeto.Application.Adaptatives;
using Empresa.Projeto.Application.Dtos.Unidade;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationUnidade : IApplicationBase<ViewUnidadeDto, PostUnidadeDto, PutUnidadeDto>
    {
        Task<UnidadeAdaptative> GetByIdDetalhesAdaptativeAsync(long id);
    }
}
