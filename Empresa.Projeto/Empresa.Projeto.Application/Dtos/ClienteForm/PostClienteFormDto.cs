using Microsoft.AspNetCore.Http;

namespace Empresa.Projeto.Application.Dtos.ClienteForm
{
    public class PostClienteFormDto
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public IFormFile ImagemUpload { get; set; }
    }
}
