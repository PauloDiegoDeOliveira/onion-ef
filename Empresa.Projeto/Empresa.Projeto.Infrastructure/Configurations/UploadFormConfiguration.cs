using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Projeto.Infrastructure.Configurations
{
    public class UploadFormConfiguration : ConfigurationUploadFormBase<UploadForm>
    {
        public override void Configure(EntityTypeBuilder<UploadForm> builder)
        {
            tableName = "UploadForm";

            base.Configure(builder);
        }
    }
}