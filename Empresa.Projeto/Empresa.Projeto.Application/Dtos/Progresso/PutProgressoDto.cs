using Empresa.Projeto.Domain.Enums;

namespace Empresa.Projeto.Application.Dtos.Progresso
{
    public class PutProgressoDto
    {
        public int Id { get; set; }

        public int TotalProgresso { get; set; }

        public Status Status { get; set; }
    }
}
