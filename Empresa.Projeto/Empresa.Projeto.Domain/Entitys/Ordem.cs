using System;
using System.Collections.Generic;

namespace Empresa.Projeto.Domain.Entitys
{
    public class Ordem : EntityBase
    {
        // Propriedades
        public DateTime Data { get; private set; }

        public string Descricao { get; private set; }

        // Propriedades de navegação
        public virtual IList<Usuario> Usuarios { get; private set; }

        // EF
        protected Ordem()
        { }

        // Construtor
        public Ordem(string descricao,
                      DateTime data)
        {
            Descricao = descricao;
            Data = data;
        }

        // Metodos
    }
}