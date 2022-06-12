using System.Collections.Generic;

namespace Empresa.Projeto.Domain.Entitys
{
    public class Especialidade : EntityBase
    {
        // Propriedades
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        // Propriedades de navegação
        public virtual IList<Usuario> Usuarios { get; private set; }

        // EF
        protected Especialidade()
        { }

        // Construtor
        public Especialidade(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        // Métodos/Comportamentos
    }
}