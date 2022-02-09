using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Projeto.Infrastructure.Configurations
{
    public class EspecialidadeConfiguration : ConfigurationBase<Especialidade>
    {
        public override void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            tableName = "Especialidade";

            base.Configure(builder);

            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                   .HasMaxLength(200)
                   .HasColumnName("Descricao")
                   .HasColumnType("varchar(200)");
        }
    }
}