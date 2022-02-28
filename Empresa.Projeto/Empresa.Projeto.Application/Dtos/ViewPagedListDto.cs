using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Pagination;
using System.Collections.Generic;

namespace Empresa.Projeto.Application.Dtos
{
    public class ViewPagedListDto <TEntity, TView> where TEntity : EntityBase where TView : class
    {
        public ICollection<TView> Pagina { get; set; }
        public ViewPaginationDto<TEntity> Dados { get; set; }

        public ViewPagedListDto(PagedList<TEntity> pagedList)
        {
            Pagina = new List<TView>();
            Dados = new ViewPaginationDto<TEntity>(pagedList);
        }
    }
}
