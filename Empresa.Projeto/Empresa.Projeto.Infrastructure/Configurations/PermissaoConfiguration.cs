using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Projeto.Infrastructure.Configurations
{
    public class PermissaoConfiguration : ConfigurationBase<Permissao>
    {
        public override void Configure(EntityTypeBuilder<Permissao> builder)
        {
            tableName = "Permissao";

            base.Configure(builder);

            builder.Property(x => x.Id)
                   .UseIdentityColumn()
                   .HasColumnType("bigint");

            builder.Property(p => p.Nome)
                   .HasMaxLength(100)
                   .IsRequired()
                   .HasColumnName("Nome")
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                   .HasMaxLength(100)
                   .HasColumnName("Descricao")
                   .HasColumnType("varchar(100)");
        }
    }
}