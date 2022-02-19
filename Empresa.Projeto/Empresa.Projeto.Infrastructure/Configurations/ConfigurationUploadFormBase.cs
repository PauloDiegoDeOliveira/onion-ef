using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Projeto.Infrastructure.Configurations
{
    public class ConfigurationUploadFormBase<TEntity> : ConfigurationBase <TEntity> where TEntity : UploadFormBase
    {
        public new virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.IdGuid)
                   .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.TamanhoEmBytes)
                   .HasMaxLength(100)
                   .HasColumnName("TamanhoEmBytes")
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.ContentType)
                   .HasMaxLength(100)
                   .HasColumnName("ContentType")
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.ExtensaoArquivo)
                   .HasMaxLength(100)
                   .HasColumnName("ExtensaoArquivo")
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.NomeArquivoOriginal)
                  .HasMaxLength(300)
                  .HasColumnName("NomeArquivoOriginal")
                  .HasColumnType("varchar(300)");

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