using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Projeto.Infrastructure.Configurations
{
    public class OrdemConfiguration : ConfigurationBase<Ordem>
    {
        public override void Configure(EntityTypeBuilder<Ordem> builder)
        {
            tableName = "Ordem";

            base.Configure(builder);

            builder.Property(x => x.Id)
                   .UseIdentityColumn()
                   .HasColumnType("bigint");         

            builder.Property(p => p.Descricao)
                   .HasMaxLength(200)
                   .HasColumnName("Descricao")
                   .HasColumnType("varchar(200)");
        }
    }
}