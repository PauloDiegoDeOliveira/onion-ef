using System;

namespace Empresa.Projeto.Domain.Entitys
{
    public abstract class EntityBase
    {
        // Propriedades
        public long Id { get; private set; }

        public int Status { get; private set; }
        public DateTime? CriadoEm { get; private set; }
        public DateTime? AlteradoEm { get; private set; }

        // EF
        protected EntityBase()
        { }

        // Construtor
        protected EntityBase(long id,
                       int status,
                       DateTime? criadoEm,
                       DateTime? alteradoEm)
        {
            Id = id;
            Status = status;
            CriadoEm = criadoEm;
            AlteradoEm = alteradoEm;
        }

        // Métodos/Comportamentos
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