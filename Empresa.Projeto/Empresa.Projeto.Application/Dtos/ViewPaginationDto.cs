using Empresa.Projeto.Domain.Pagination;

namespace Empresa.Projeto.Application.Dtos
{
    public class ViewPaginationDto<T>
    {
        public int PaginaAtual { get; private set; }
        public int TotalPaginas { get; private set; }
        public int TamanhoResultadosExibidos { get; private set; }
        public int ContagemTotalResultados { get; private set; }
        public bool ExistePaginaAnterior { get; private set; }
        public bool ExistePaginaPosterior { get; private set; }

        public ViewPaginationDto(PagedList<T> pagedList)
        {
            ContagemTotalResultados = pagedList.ContagemTotalResultados;
            TamanhoResultadosExibidos = pagedList.TamanhoResultadosExibidos;
            PaginaAtual = pagedList.PaginaAtual;
            TotalPaginas = pagedList.TotalPaginas;
            ExistePaginaPosterior = pagedList.ExistePaginaPosterior;
            ExistePaginaAnterior = pagedList.ExistePaginaAnterior;
        }
    }
}
