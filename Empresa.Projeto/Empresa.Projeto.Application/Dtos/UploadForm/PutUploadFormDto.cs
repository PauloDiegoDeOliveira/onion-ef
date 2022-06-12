using Microsoft.AspNetCore.Http;

namespace Empresa.Projeto.Application.Dtos.UploadForm
{
    public class PutUploadFormDto
    {
        public long Id { get; set; }
        public IFormFile ImagemUpload { get; set; }
    }
}