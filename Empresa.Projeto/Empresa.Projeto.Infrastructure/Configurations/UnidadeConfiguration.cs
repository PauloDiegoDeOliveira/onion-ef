using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Projeto.Infrastructure.Configurations
{
    public class UnidadeConfiguration : ConfigurationBase<Unidade>
    {
        public override void Configure(EntityTypeBuilder<Unidade> builder)
        {
            tableName = "Unidade";

            base.Configure(builder);

            builder.Property(p => p.NumeroUnidade)
               .HasMaxLength(1000)
               .IsRequired()
               .HasColumnName("NumeroCapitulo")
               .HasColumnType("int");
        }
    }
}
