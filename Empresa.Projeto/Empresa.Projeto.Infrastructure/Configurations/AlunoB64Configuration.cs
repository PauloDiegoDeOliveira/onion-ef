using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Projeto.Infrastructure.Configurations
{
    public class AlunoB64Configuration : ConfigurationUploadB64Base<AlunoB64>
    {
        public override void Configure(EntityTypeBuilder<AlunoB64> builder)
        {
            tableName = "AlunoB64";

            base.Configure(builder);

            builder.Property(p => p.Nome)
                  .HasMaxLength(100)
                  .IsRequired()
                  .HasColumnName("Nome")
                  .HasColumnType("varchar(100)");

            builder.Property(p => p.Sobrenome)
                   .HasMaxLength(100)
                   .HasColumnName("Sobrenome")
                   .HasColumnType("varchar(100)");
        }
    }
}
