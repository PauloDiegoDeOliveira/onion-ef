using Empresa.Projeto.Application.Dtos.UploadB64;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationUploadB64 : IApplicationBase<ViewUploadB64Dto, PostUploadB64Dto, PutUploadB64Dto>
    {
        Task<ViewUploadB64Dto> PostAsync(PostUploadB64Dto postUploadB64, string caminhoAbsoluto, string caminhoRelativo);

        Task<ViewUploadB64Dto> PutAsync(PutUploadB64Dto putUploadB64, string caminhoAbsoluto, string caminhoRelativo);
    }
}
