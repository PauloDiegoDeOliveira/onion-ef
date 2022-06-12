using System.Collections.Generic;

namespace Empresa.Projeto.Domain.Entitys
{
    public class Capitulo : EntityBase
    {

        public int NumeroCapitulo { get; set; }

        public List<Progresso> Progressos { get; set; }

        public List<Unidade> Unidades { get; set; }

        protected Capitulo()
        { }

        protected Capitulo(int numeroCapitulo, List<Progresso> progressos, List<Unidade> unidades)
        {
            NumeroCapitulo = numeroCapitulo;
            Progressos = progressos;
            Unidades = unidades;
        }

        public void ChangeProgressoValue(List<Progresso> progressos)
        {
            Progressos = progressos;
        }
    }
}
