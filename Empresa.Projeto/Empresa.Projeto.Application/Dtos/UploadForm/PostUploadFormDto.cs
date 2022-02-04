using Microsoft.AspNetCore.Http;

namespace Empresa.Projeto.Application.Dtos.UploadForm
{
    public class PostUploadFormDto
    {
        public IFormFile ImagemUpload { get; set; }
    }
}