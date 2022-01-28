using System;
using System.Collections.Generic;

namespace Empresa.Projeto.Domain.Entitys
{
    public class Permissao : EntityBase
    {
        // Propriedades
        public string NomePermissao { get; private set; }
        public string Descricao { get; private set; }

        // Propriedades de navegação
        public IList<Usuario> Usuarios { get; private set; }

        // EF
        protected Permissao()
        { }

        // Construtor
        public Permissao(string nomePermissao,
                       string descricao,
                       IList<Usuario> usuarios)
        {
            NomePermissao = nomePermissao;
            Descricao = descricao;
            Usuarios = usuarios;
        }

        // Metodos
    }
}