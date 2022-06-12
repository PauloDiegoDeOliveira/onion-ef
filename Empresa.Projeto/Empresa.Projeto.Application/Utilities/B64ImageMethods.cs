using Empresa.Projeto.Domain.Entitys;
using System.IO;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Utilities
{
    public class B64ImageMethods<TEntity> where TEntity : UploadB64Base
    {
        public async Task UploadImagem(string caminho, byte[] imageDataByteArray)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), caminho);
            await File.WriteAllBytesAsync(filePath, imageDataByteArray);
        }

        public async Task DeleteImage(TEntity uploadB64)
        {
            if (File.Exists(uploadB64.CaminhoAbsoluto))
            {
                File.Delete(uploadB64.CaminhoAbsoluto);
            }
            await Task.CompletedTask;
        }
    }
}
