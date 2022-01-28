using System;
using System.Collections.Generic;

namespace Empresa.Projeto.Domain.Entitys
{
    public class Usuario : EntityBase
    {
        // Propriedades
        public long PermissaoId { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Apelido { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        // Propriedades de navegação
        public IList<Permissao> Permissoes { get; private set; }

        // EF
        protected Usuario()
        { }

        // Construtor
        public Usuario(long permissaoId,
                       string nome,
                       string sobrenome,
                       string apelido,
                       string email,
                       string senha,
                       IList<Permissao> permissoes)
        {
            PermissaoId = permissaoId;
            Nome = nome;
            Sobrenome = sobrenome;
            Apelido = apelido;
            Email = email;
            Senha = senha;
            Permissoes = permissoes;
        }

        // Metodos
    }
}