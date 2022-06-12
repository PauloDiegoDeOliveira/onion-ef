using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Projeto.Infrastructure.Configurations
{
    public class UploadB64Configuration : ConfigurationUploadB64Base<UploadB64>
    {
        public override void Configure(EntityTypeBuilder<UploadB64> builder)
        {
            tableName = "UploadB64";

            base.Configure(builder);
        }
    }
}