using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Projeto.Infrastructure.Configurations
{
    public class UploadB64Configuration : ConfigurationBase<UploadB64>
    {
        public override void Configure(EntityTypeBuilder<UploadB64> builder)
        {
            tableName = "UploadB64";

            base.Configure(builder);

            builder.Property(x => x.IdGuid)
                  .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.CaminhoRelativo)
                  .HasMaxLength(300)
                  .HasColumnName("CaminhoRelativo")
                  .HasColumnType("varchar(300)");

            builder.Property(p => p.CaminhoAbsoluto)
                  .HasMaxLength(300)
                  .HasColumnName("CaminhoAbsoluto")
                  .HasColumnType("varchar(300)");
        }
    }
}
