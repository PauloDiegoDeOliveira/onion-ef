using System;
using System.Collections.Generic;
using System.Linq;

namespace Empresa.Projeto.Domain.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int PaginaAtual { get; private set; }
        public int TotalPaginas { get; private set; }
        public int TamanhoResultadosExibidos { get; private set; }
        public int ContagemTotalResultados { get; private set; }

        public bool ExistePaginaAnterior => PaginaAtual > 1 && TotalPaginas > 1;
        public bool ExistePaginaPosterior => PaginaAtual < TotalPaginas;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            ContagemTotalResultados = count;
            TamanhoResultadosExibidos = pageSize;
            PaginaAtual = pageNumber;
            TotalPaginas = (int)Math.Ceiling(count/(double)pageSize);

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var count = query.Count();
            var items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        public List<T> ReturnList<T>(PagedList<T> pagedList)
        {
            List<T> retorno = new List<T>();
            foreach (T item in pagedList)
            {
                retorno.Add(item);
            }
            return retorno;
        }
    }
}
