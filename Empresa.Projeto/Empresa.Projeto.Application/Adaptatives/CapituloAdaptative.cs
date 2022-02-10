using Empresa.Projeto.Application.Dtos.Capitulo;
using Empresa.Projeto.Application.Dtos.Progresso;
using Empresa.Projeto.Domain.Enums;

namespace Empresa.Projeto.Application.Adaptatives
{
    public class CapituloAdaptative
    {
        public int Id { get; set; }
        public int NumeroCapitulo { get; set; }
        public ViewProgressoDto Progresso { get; set; }
        public Status Status { get; set; }

        public void Construtor(ViewCapituloDto viewCapituloDto)
        {
            Id = viewCapituloDto.Id;
            NumeroCapitulo = viewCapituloDto.NumeroCapitulo;
            Status = viewCapituloDto.Status;
            Progresso = viewCapituloDto.Progressos[0];
        }
    }
}
