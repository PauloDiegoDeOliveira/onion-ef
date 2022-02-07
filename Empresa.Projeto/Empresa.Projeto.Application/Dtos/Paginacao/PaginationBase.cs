namespace Empresa.Projeto.Application.Dtos.Paginacao
{
    public class PaginationBase
    {
        public int ContagemTotal { get; private set; }
        public int ResultadosExibidos { get; private set; }
        public int PaginaAtual { get; private set; }
        public int TotalPaginas { get; private set; }
        public bool ExistePaginaPosterior { get; private set; }
        public bool ExistePaginaAnterior { get; private set; }

        public void SetValues(int contagemTotal, int tamanhoPagina, int paginaAtual)
        {
            ContagemTotal = contagemTotal;
            ResultadosExibidos = tamanhoPagina;
            PaginaAtual = paginaAtual;
            TotalPaginas = CheckTotalPages();
            ExistePaginaPosterior = CheckHasNextPage();
            ExistePaginaAnterior = CheckHasPreviousPage();
            CheckExceedPageLimit();
        }

        public void CheckExceedPageLimit()
        {
            if (PaginaAtual > TotalPaginas)
                PaginaAtual = TotalPaginas;
        }

        public int CheckTotalPages()
        {
            return (ContagemTotal / ResultadosExibidos);
        }

        public bool CheckHasNextPage()
        {
            return PaginaAtual < TotalPaginas ? true : false;
        }

        public bool CheckHasPreviousPage()
        {
            return PaginaAtual > 1 && TotalPaginas > 1 ? true : false;
        }
    }
}