namespace Empresa.Projeto.Domain.Entitys
{
    public class Progresso : EntityBase
    {
        public int TotalProgresso { get; private set; }

        public Capitulo Capitulo { get; private set; }

        protected Progresso()
        { }

        protected Progresso(int totalProgresso, Capitulo capitulo)
        {
            TotalProgresso = totalProgresso;
            Capitulo = capitulo;
        }
    }
}
