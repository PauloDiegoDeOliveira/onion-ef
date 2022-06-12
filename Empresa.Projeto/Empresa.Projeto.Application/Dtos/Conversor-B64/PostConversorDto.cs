using Microsoft.AspNetCore.Http;

namespace Empresa.Projeto.Application.Dtos.Conversor_B64
{
    public class PostConversorDto
    {
        public IFormFile ImagemUpload { get; set; }
    }
}
