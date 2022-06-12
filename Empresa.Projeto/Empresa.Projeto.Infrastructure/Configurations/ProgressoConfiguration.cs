using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Projeto.Infrastructure.Configurations
{
    public class ProgressoConfiguration : ConfigurationBase<Progresso>
    {
        public override void Configure(EntityTypeBuilder<Progresso> builder)
        {
            tableName = "Progresso";

            base.Configure(builder);

            builder.Property(p => p.TotalProgresso)
                   .HasMaxLength(100)
                   .IsRequired()
                   .HasColumnName("TotalProgresso")
                   .HasColumnType("int")
                   .HasDefaultValue(0);
        }
    }
}
