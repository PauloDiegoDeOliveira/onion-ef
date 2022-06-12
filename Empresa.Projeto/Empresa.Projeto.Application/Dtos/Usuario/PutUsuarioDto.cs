using Empresa.Projeto.Application.Dtos.Especialidade;
using Empresa.Projeto.Domain.Enums;
using System.Collections.Generic;

namespace Empresa.Projeto.Application.Dtos.Usuario
{
    public class PutUsuarioDto
    {
        public long Id { get; set; }
        public long PermissaoId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Status Status { get; set; }

        public List<ReferenciaEspecialidadeDto> Especialidades { get; set; }
    }
}