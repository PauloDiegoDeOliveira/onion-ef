using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Domain.Enums;
using System.Collections.Generic;

namespace Empresa.Projeto.Application.Dtos.Permissao
{
    public class ViewPermissaoUsuarioDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Status Status { get; set; }

        public List<ViewUsuarioDto> Usuarios { get; set; }
    }
}