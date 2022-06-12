using Empresa.Projeto.Application.Dtos.AlunoB64;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationAlunoB64 : IApplicationBase<ViewAlunoB64Dto, PostAlunoB64Dto, PutAlunoB64Dto>
    {
        Task<ViewAlunoB64Dto> PostAsync(PostAlunoB64Dto postAlunoB64Dto, string caminhoAbsoluto, string caminhoRelativo);

        Task<ViewAlunoB64Dto> PutAsync(PutAlunoB64Dto putAlunoB64Dto, string caminhoAbsoluto, string caminhoRelativo);
    }
}
