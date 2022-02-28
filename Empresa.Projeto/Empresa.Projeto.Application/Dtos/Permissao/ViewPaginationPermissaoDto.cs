using Empresa.Projeto.Domain.Pagination;
using System.Collections.Generic;

namespace Empresa.Projeto.Application.Dtos.Permissao
{
    public class ViewPaginationPermissaoDto
    {
        public ICollection<ViewPermissaoDto> Permissoes { get; set; }
        public ViewPagination<Domain.Entitys.Permissao> DadosPaginacao { get; set; }

        public ViewPaginationPermissaoDto(PagedList<Domain.Entitys.Permissao> pagedList)
        {
            DadosPaginacao = new ViewPagination<Domain.Entitys.Permissao>(pagedList);
            Permissoes = new List<ViewPermissaoDto>();
        }
    }
}
