using System;
using System.Collections.Generic;

namespace Empresa.Projeto.Domain.Entitys
{
    public class Permissao : EntityBase
    {
        // Propriedades
        public string NomePermissao { get; private set; }

        public string Descricao { get; private set; }
        public int Status { get; private set; }
        public DateTime? CriadoEm { get; private set; }
        public DateTime? AlteradoEm { get; private set; }

        // Propriedades de navegação
        public IList<Usuario> Usuarios { get; private set; }

        // EF
        protected Permissao()
        { }

        // Construtor
        public Permissao(string nomePermissao,
                       string descricao,
                       int status,
                       DateTime? criadoEm,
                       DateTime? alteradoEm,
                       IList<Usuario> usuarios)
        {
            NomePermissao = nomePermissao;
            Descricao = descricao;
            Status = status;
            CriadoEm = criadoEm;
            AlteradoEm = alteradoEm;
            Usuarios = usuarios;
        }

        // Metodos
        public void ChangeStatusValue(int status)
        {
            Status = status;
        }

        public void ChangeAlteradoEmValue(DateTime data)
        {
            AlteradoEm = data;
        }
    }
}