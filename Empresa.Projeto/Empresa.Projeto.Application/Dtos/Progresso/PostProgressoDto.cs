using Empresa.Projeto.Domain.Enums;

namespace Empresa.Projeto.Application.Dtos.Progresso
{
    public class PostProgressoDto
    {
        public int TotalProgresso { get; set; }

        public Status Status { get; set; }
    }
}
