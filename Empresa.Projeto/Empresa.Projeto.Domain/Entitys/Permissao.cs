using System.Collections.Generic;

namespace Empresa.Projeto.Domain.Entitys
{
    public class Permissao : EntityBase
    {
        // Propriedades
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        // Propriedades de navegação
        public virtual IList<Usuario> Usuarios { get; private set; }

        // EF
        protected Permissao()
        { }

        // Construtor
        public Permissao(string nome,
                       string descricao,
                       IList<Usuario> usuarios)
        {
            Nome = nome;
            Descricao = descricao;
            Usuarios = usuarios;
        }

        // Métodos/Comportamentos
    }
}