using Empresa.Projeto.Application.Dtos.Permissao;
using System.Collections.Generic;

namespace Empresa.Projeto.Application.Dtos.Paginacao
{
    public class PermissaoPagination : PaginationBase
    {
        public List<ViewPermissaoDto> Permissoes { get; set; }
    }
}