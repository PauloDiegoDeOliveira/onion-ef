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
        public DateTime? UltimoAcessoEm { get; private set; }


        // Propriedades de navegação
        public virtual Permissao Permissao { get; private set; }
        public virtual List<Especialidade> Especialidades { get; private set; }

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
                       DateTime? ultimoAcessoEm,
                       Permissao permissao,
                       List<Especialidade> especialidades)
        {
            PermissaoId = permissaoId;
            Nome = nome;
            Sobrenome = sobrenome;
            Apelido = apelido;
            Email = email;
            Senha = senha;
            UltimoAcessoEm = ultimoAcessoEm;
            Permissao = permissao;
            Especialidades = especialidades;
        }

        // Métodos/Comportamentos
        public void ChangeEspecialidadesValue(List<Especialidade> especialidades) 
        {
            Especialidades = especialidades;
        }

        public void ChangeUltimoAcessoEmValue(DateTime date)
        {
            UltimoAcessoEm = date;
        }
    }
}