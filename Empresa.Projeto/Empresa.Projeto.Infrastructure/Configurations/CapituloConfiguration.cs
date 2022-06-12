using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Projeto.Infrastructure.Configurations
{
    public class CapituloConfiguration : ConfigurationBase<Capitulo>
    {
        public override void Configure(EntityTypeBuilder<Capitulo> builder)
        {
            tableName = "Capitulo";

            base.Configure(builder);

            builder.Property(p => p.NumeroCapitulo)
               .HasMaxLength(1000)
               .IsRequired()
               .HasColumnName("NumeroCapitulo")
               .HasColumnType("int");
        }
    }
}
