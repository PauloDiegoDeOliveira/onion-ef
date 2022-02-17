using Empresa.Projeto.Application.Dtos.ClienteForm;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationClienteForm : IApplicationBase<ViewClienteFormDto, PostClienteFormDto, PutClienteFormDto>
    {
        Task<ViewClienteFormDto> PostAsync(PostClienteFormDto postClienteFormDto, string caminhoAbsoluto, string caminhoRelativo);

        Task<ViewClienteFormDto> PutAsync(PutClienteFormDto putClienteFormDto, string caminhoAbsoluto, string caminhoRelativo);
    }
}
