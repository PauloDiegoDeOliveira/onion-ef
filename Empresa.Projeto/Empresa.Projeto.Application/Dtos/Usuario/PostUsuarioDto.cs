using Empresa.Projeto.Domain.Enums;

namespace Empresa.Projeto.Application.Dtos.Usuario
{
    public class PostUsuarioDto
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Status Status { get; set; }
    }
}