using Empresa.Projeto.Domain.Enums;

namespace Empresa.Projeto.Application.Dtos.Especialidade
{
    public class ViewEspecialidadeDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Status Status { get; set; }
    }
}