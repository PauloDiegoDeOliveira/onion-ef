using Empresa.Projeto.Domain.Entitys;
using System.IO;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Utilities
{
    public class FormImageMethods<TEntity> where TEntity : UploadFormBase
    {
        public async Task UploadImage(TEntity uploadForm)
        {
            string root = Path.Combine(Directory.GetCurrentDirectory(), uploadForm.CaminhoAbsoluto);
            using (var stream = new FileStream(root, FileMode.Create))
            {
                await uploadForm.ImagemUpload.CopyToAsync(stream);
            }
        }

        public async Task DeleteImage(TEntity uploadForm)
        {
            if (File.Exists(uploadForm.CaminhoAbsoluto))
            {
                File.Delete(uploadForm.CaminhoAbsoluto);
            }
            await Task.CompletedTask;
        }
    }
}