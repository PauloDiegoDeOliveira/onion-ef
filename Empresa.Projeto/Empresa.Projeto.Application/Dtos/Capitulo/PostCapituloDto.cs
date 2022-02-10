using Empresa.Projeto.Application.Dtos.Progresso;
using Empresa.Projeto.Domain.Enums;
using System.Collections.Generic;

namespace Empresa.Projeto.Application.Dtos.Capitulo
{
    public class PostCapituloDto
    {
        public int NumeroCapitulo { get; set; }

        public Status Status { get; set; }

        public List<ReferenciaProgressoDto> Progressos { get; set; }
    }
}
