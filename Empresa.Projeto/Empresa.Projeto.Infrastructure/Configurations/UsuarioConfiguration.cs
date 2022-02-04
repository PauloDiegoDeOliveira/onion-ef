using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Projeto.Infrastructure.Configurations
{
    public class UsuarioConfiguration : ConfigurationBase<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            tableName = "Usuario";

            base.Configure(builder);

            builder.Property(x => x.PermissaoId)
                   .IsRequired()
                   .HasColumnName("PermissaoId")
                   .HasColumnType("bigint");

            builder.Property(p => p.Nome)
                   .HasMaxLength(100)
                   .IsRequired()
                   .HasColumnName("Nome")
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Sobrenome)
                   .HasMaxLength(100)
                   .HasColumnName("Sobrenome")
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Apelido)
                   .HasMaxLength(100)
                   .HasColumnName("Apelido")
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Email)
                   .HasMaxLength(100)
                   .HasColumnName("Email")
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Senha)
                   .HasMaxLength(500)
                   .HasColumnName("Senha")
                   .HasColumnType("varchar(500)");
        }
    }
}