using System;

namespace Empresa.Projeto.Domain.Entitys
{
    public class Usuario : Base
    { 
        // Propriedades
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Apelido { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public int Status { get; private set; }
        public DateTime? CriadoEm { get; private set; }
        public DateTime? AlteradoEm { get; private set; }     

        // Propriedades de navegação
        //public IList<Permissao> Permissoes { get; private set; } 

        // EF
        protected Usuario() { }

        // Construtor
        public Usuario(string nome,
                       string sobrenome,
                       string apelido,
                       string email,
                       string senha,
                       int status,
                       DateTime? criadoEm,
                       DateTime? alteradoEm)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Apelido = apelido;
            Email = email;
            Senha = senha;
            Status = status;
            CriadoEm = criadoEm;
            AlteradoEm = alteradoEm;
        }

        // Metodos
    }
}