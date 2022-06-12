using Empresa.Projeto.Application.Dtos.UploadForm;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Interfaces
{
    public interface IApplicationUploadForm : IApplicationBase<ViewUploadFormDto, PostUploadFormDto, PutUploadFormDto>
    {
        Task<ViewUploadFormDto> PostAsync(PostUploadFormDto postUploadForm, string caminhoAbsoluto, string caminhoRelativo);

        Task<ViewUploadFormDto> PutAsync(PutUploadFormDto putUploadForm, string caminhoAbsoluto, string caminhoRelativo);
    }
}