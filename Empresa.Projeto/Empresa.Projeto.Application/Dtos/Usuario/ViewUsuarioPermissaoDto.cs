using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Domain.Enums;

namespace Empresa.Projeto.Application.Dtos.Usuario
{
    public class ViewUsuarioPermissaoDto
    {
        public long Id { get; set; }
        public long PermissaoId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }

        public ViewPermissaoDto Permissao { get; set; }
    }
}