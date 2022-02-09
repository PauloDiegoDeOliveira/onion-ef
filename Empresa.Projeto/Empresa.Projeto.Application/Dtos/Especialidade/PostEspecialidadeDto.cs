using Empresa.Projeto.Domain.Enums;

namespace Empresa.Projeto.Application.Dtos.Especialidade
{
    public class PostEspecialidadeDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Status Status { get; set; }
    }
}