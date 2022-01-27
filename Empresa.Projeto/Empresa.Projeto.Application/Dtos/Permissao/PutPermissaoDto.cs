using Empresa.Projeto.Domain.Enums;

namespace Empresa.Projeto.Application.Dtos.Permissao
{
    public class PutPermissaoDto
    {
        public long Id { get; set; }
        public string NomePermissao { get; set; }
        public string Descricao { get; set; }
        public Status Status { get; set; }
    }
}
