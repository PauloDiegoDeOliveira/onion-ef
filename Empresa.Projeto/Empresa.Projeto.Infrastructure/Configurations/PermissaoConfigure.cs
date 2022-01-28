using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Projeto.Infrastructure.Configurations
{
    public class PermissaoConfigure : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.ToTable("Permissoes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .UseIdentityColumn()
                   .HasColumnType("bigint");

            builder.Property(p => p.NomePermissao)
                   .HasMaxLength(100)
                   .IsRequired()
                   .HasColumnName("NomePermissao")
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                   .HasMaxLength(100)
                   .HasColumnName("Descricao")
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Status)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("Status")
                   .HasColumnType("int")
                   .HasDefaultValue(1);
        }
    }
}