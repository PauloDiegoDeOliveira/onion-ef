using Microsoft.AspNetCore.Http;

namespace Empresa.Projeto.Application.Dtos.ClienteForm
{
    public class PutClienteFormDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public IFormFile ImagemUpload { get; set; }
    }
}
