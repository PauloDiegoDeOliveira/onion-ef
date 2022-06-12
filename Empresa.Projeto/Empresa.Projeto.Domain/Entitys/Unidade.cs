using System.Collections.Generic;

namespace Empresa.Projeto.Domain.Entitys
{
    public class Unidade : EntityBase
    {
        public int NumeroUnidade { get; set; }

        public List<Capitulo> Capitulos { get; set; }

        protected Unidade()
        { }

        protected Unidade(int numeroUnidade, List<Capitulo> capitulos)
        {
            NumeroUnidade = numeroUnidade;
            Capitulos = capitulos;
        }

        public void ChangeCapituloValue(List<Capitulo> capitulos)
        {
            Capitulos = capitulos;
        }
    }
}
